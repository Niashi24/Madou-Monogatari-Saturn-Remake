using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using LS.SearchWindows;
using LS.Utilities;

public class ValueAsset<T> : ScriptableObject, IValueSupplier<T>
{
    [SerializeField]
    T _initialValue;

    [SerializeField, DisableInEditorMode]
    T _value;

    [ShowInInspector, ReadOnly]
    public T PreviousValue {get; private set;}

    [SerializeField]
    [AssetSearch]
    EventAsset<T> _onValueChanged;

    public T Value 
    {
        get => _value;
        set 
        {
            PreviousValue = this._value;
            this._value = value;

            if (_onValueChanged is not null)
                _onValueChanged.Invoke(value);
        }
    }

    void OnEnable()
    {
        _value = _initialValue;
        PreviousValue = _initialValue; 
    }

    public void Reset()
    {
        _value = _initialValue;
        PreviousValue = _initialValue;
    }
}