using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilKeyPressed : CutsceneAction
{
    [SerializeField]
    KeyCode _key;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(_key));
    }
}
