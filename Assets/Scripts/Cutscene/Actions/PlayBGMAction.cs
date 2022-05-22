using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGMAction : CutsceneAction
{
    [SerializeField]
    AudioData _music;

    public override IEnumerator Execute(CutsceneContext context)
    {
        AudioManager.I.PlayBGM(_music);
        yield break;
    }
}
