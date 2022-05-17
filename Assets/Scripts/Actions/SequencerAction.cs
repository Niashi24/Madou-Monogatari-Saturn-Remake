using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerAction : CutsceneAction
{
    [SerializeReference]
    List<CutsceneAction> actions = new();

    public override IEnumerator Execute(CutsceneContext context)
    {
        foreach (var action in actions)
            yield return action.Execute(context);
    }
}
