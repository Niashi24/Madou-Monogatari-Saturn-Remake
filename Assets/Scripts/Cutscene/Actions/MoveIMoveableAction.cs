using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public class MoveIMoveableAction : CutsceneAction
{
    [SerializeField]
    ObjectReference<IMoveable> _iMoveable;

    [SerializeField]
    Vector3 _target;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return _iMoveable.Value.Move(_target);
    }
}
