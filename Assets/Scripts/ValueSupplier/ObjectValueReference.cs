using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using LS.Utilities;

[System.Serializable]
public class ObjectValueReference<T>
    where T : class
{
    [SerializeField]
    [HideLabel]
    [BoolDropdown("Use Value", "Use Value Supplier")]
    [Tooltip("Use Reference")]
    [HorizontalGroup(width: BoolDropdown.PopupWidth)]
    [PropertyOrder(0)]
    private bool useReference;

    [SerializeField]
    [HideLabel]
    [HorizontalGroup]
    [HideIf(nameof(useReference), true)]
    [PropertyOrder(1)]
    ObjectReference<T> value;

    [SerializeField]
    [HideLabel]
    [HorizontalGroup]
    [ShowIf(nameof(useReference), true)]
    [PropertyOrder(2)]
    ObjectReference<IValueSupplier<T>> reference;

    public ObjectValueReference(T value)
    {
        this.value = new ObjectReference<T>(value);
    }

    [ShowInInspector, ReadOnly]
    [PropertyOrder(1)]
    [HorizontalGroup]
    [HideLabel]
    [ShowIf(nameof(useReference), true)]
    public T Value 
    {
        get 
        {
            if (useReference)
                return reference.HasValue ? reference.Value.Value : default;
            else
                return value.Value;
        }
        set
        {
            if (useReference)
                reference.Value.Value = value;
            else
                this.value = new ObjectReference<T>(value);
        }
    }
}
