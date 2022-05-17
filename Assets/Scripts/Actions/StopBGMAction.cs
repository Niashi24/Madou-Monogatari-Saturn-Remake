using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBGMAction : CutsceneAction
{
    public override IEnumerator Execute(CutsceneContext context)
    {
        AudioManager.I.StopBGM();
        yield break;
    }
}
