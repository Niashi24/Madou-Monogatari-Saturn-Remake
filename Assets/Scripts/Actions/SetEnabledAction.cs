using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnabledAction : CutsceneAction
{
    [SerializeField]
    Behaviour _behavior;

    [SerializeField]
    bool _enabled;

    public override IEnumerator Execute(CutsceneContext context)
    {
        _behavior.enabled = _enabled;
        yield break;
    }
}
