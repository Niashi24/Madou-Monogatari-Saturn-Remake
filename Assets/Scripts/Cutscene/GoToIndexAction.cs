using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoToIndexAction : CutsceneAction
{
    [SerializeField]
    int index;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield break;
    }

    public override int GetNextActionIndex(CutsceneContext context)
    {
        return index;
    }
}
