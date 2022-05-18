using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXFullAction : CutsceneAction
{
    [SerializeField]
    AudioData _sfx;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return AudioManager.I.PlaySFXCoroutine(_sfx);
    }
}
