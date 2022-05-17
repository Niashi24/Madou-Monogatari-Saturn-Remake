using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaitAction : CutsceneAction
{
    [SerializeField]
    float _seconds;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return new WaitForSeconds(_seconds);
    }
}
