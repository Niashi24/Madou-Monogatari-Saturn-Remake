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

    // [SerializeField]
    // [AssetSearch]
    // EventAsset<T> _event;

    public T Value 
    {
        get => _value;
        set 
        {
            this._value = value;
            // _event?.Invoke(_value);
        }
    }

    void OnEnable()
    {
        _value = _initialValue;    
    }

    public void Reset()
    {
        _value = _initialValue;
    }
}