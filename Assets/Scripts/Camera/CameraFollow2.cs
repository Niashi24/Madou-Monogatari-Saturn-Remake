using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class CameraFollow2 : MonoBehaviour
{
    [SerializeField]
    ValueReference<Vector3> _targetPosition;

    [SerializeField]
    Optional<float> _speed;

    void LateUpdate() {
        if (!_speed.Enabled) transform.position = _targetPosition.Value;

        transform.position = Vector3.MoveTowards(
            transform.position, 
            _targetPosition.Value, 
            _speed.Value * Time.deltaTime
        );     
    }
}
