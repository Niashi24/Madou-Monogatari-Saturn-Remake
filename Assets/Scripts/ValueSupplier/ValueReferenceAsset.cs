using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public class ValueReferenceAsset<TSupplier, TValue> : ScriptableObject, IValueSupplier<TValue>
    where TSupplier : IValueSupplier<TValue>
{
    [SerializeField]
    TSupplier _value;

    public TValue Value
    {
        get => _value.Value;
        set {_value.Value = value;}
    }
}
