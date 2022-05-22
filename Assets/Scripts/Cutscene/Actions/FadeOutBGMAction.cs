using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutBGMAction : CutsceneAction
{
    [SerializeField]
    float seconds;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return AudioManager.I.FadeOutBGM(seconds);
    }
}
