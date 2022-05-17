using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventAction : CutsceneAction
{
    [SerializeField]
    UnityEvent _event;

    public override IEnumerator Execute(CutsceneContext context)
    {
        _event?.Invoke();
        yield break;
    }
}
