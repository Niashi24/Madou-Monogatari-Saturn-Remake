using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAction : CutsceneAction
{
    public override IEnumerator Execute(CutsceneContext context)
    {
        yield break;
    }
}
