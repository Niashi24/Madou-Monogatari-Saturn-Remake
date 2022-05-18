using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXAction : CutsceneAction
{
    [SerializeField]
    AudioData _sfx;

    [SerializeField]
    bool _waitUntilCompleted;

    public override IEnumerator Execute(CutsceneContext context)
    {
        if (_waitUntilCompleted)
            yield return AudioManager.I.PlaySFXCoroutine(_sfx);
        else
            AudioManager.I.PlaySFX(_sfx);
    }
}
