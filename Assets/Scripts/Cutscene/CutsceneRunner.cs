using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CutsceneRunner : MonoBehaviour, ICutsceneRunner
{
    [SerializeReference]
    List<CutsceneAction> actions = new();

    [SerializeField]
    bool onStart = true;

    Coroutine currentCutscene;

    [ShowInInspector, ReadOnly]
    public CutsceneAction CurrentAction {get; private set;}

    void Start() {
        if (onStart)
            RunCutscene();
    }

    [Button]
    public void RunCutscene()
    {
        if (currentCutscene != null)
            StopCoroutine(currentCutscene);
        currentCutscene = StartCoroutine(RunCutsceneCoroutine());
    }

    IEnumerator RunCutsceneCoroutine()
    {

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

            CurrentAction = action;

            yield return action.Execute(context);
            
            context.currentIndex = action.GetNextActionIndex(context);
        }
        
    }

    [Button]
    public void StopCutscene()
    {
        StopAllCoroutines();
    }

    Coroutine ICutsceneRunner.StartCoroutine(IEnumerator routine)
        => StartCoroutine(routine);
}
