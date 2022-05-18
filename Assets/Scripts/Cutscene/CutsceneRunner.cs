using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CutsceneRunner : MonoBehaviour
{
    [SerializeReference]
    List<CutsceneAction> actions = new();

    [SerializeField]
    bool onStart = true;

    void Start() {
        if (onStart)
            RunCutscene();
    }

    [Button]
    public void RunCutscene()
    {
        StartCoroutine(RunCutsceneCoroutine());
    }

    IEnumerator RunCutsceneCoroutine()
    {
        var prevState = GameManager.I.State;
        if (prevState == GameState.Cutscene) yield break;

        GameManager.I.ChangeState(GameState.Cutscene);

        CutsceneContext context = new()
        {
            Controller = this,
            actions = this.actions,
            currentIndex = 0
        };
        
        if (actions.Count == 0)
            yield break;

        while (context.currentIndex < actions.Count)
        {
            var action = actions[context.currentIndex];

            yield return action.Execute(context);
            
            context.currentIndex = action.GetNextActionIndex(context);
        }

        GameManager.I.ChangeState(prevState);
    }

    // [SerializeField]
    // int f;
}
