using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public class TransformGetPosition : MonoBehaviour, IValueSupplier<Vector3>
{
    [SerializeField]
    ValueReference<Transform> _transform;
    [SerializeField]
    ValueReference<Vector3> _offset = new(Vector3.zero);

    public Vector3 Value
    {
        get => _transform.Value is not null ? _transform.Value.position + _offset.Value : _offset.Value;
        set{}
    }
}
