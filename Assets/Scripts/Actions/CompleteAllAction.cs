using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompleteAllAction : CutsceneAction
{
    [SerializeReference]
    List<CutsceneAction> actions = new();

    public override IEnumerator Execute(CutsceneContext context)
    {
        Coroutine[] coroutines = new Coroutine[actions.Count];

        for (int i = 0; i < actions.Count; i++)
        {
            coroutines[i] = context.Controller.StartCoroutine(actions[i].Execute(context));
        }

        foreach (var coroutine in coroutines)
            yield return coroutine;
    }
}
