using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutsceneAction : CutsceneAction
{
    public override IEnumerator Execute(CutsceneContext context)
    {
        yield break;
    }

    public override int GetNextActionIndex(CutsceneContext context)
    {
        return context.actions.Count;
    }
}
