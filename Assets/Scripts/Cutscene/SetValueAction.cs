using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class SetValueAction<T> : CutsceneAction
{
    [SerializeField]
    ObjectReference<IValueSupplier<T>> _valueReference;

    [SerializeField]
    ValueReference<T> _newValue;

    public override IEnumerator Execute(CutsceneContext context)
    {
        _valueReference.Value.Value = _newValue.Value;
        yield break;
    }
}
