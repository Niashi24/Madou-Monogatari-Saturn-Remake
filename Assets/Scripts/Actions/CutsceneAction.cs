using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class CutsceneAction
{
    public abstract IEnumerator Execute(CutsceneContext context);

    public virtual int GetNextActionIndex(CutsceneContext context)
    {
        return context.currentIndex + 1;
    }
}
