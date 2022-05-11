using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform _targetTransform;

    [SerializeField]
    Vector3 _offset = Vector3.back * 10;

    [SerializeField]
    Vector2 _xBounds;

    [SerializeField]
    Vector2 _yBounds;
    
    void LateUpdate() {
        var targetPosition = _targetTransform.position + _offset;

        targetPosition.x = Mathf.Clamp(targetPosition.x, _xBounds.x, _xBounds.y);
        targetPosition.y = Mathf.Clamp(targetPosition.y, _yBounds.x, _yBounds.y);

        transform.position = targetPosition;
    }

    void OnDrawGizmosSelected() {
        var color = Color.white;

        Debug.DrawLine(new Vector3(_xBounds.x, _yBounds.x), new Vector3(_xBounds.y, _yBounds.x), color);

        Debug.DrawLine(new Vector3(_xBounds.y, _yBounds.x), new Vector3(_xBounds.y, _yBounds.y), color);

        Debug.DrawLine(new Vector3(_xBounds.y, _yBounds.y), new Vector3(_xBounds.x, _yBounds.y), color);

        Debug.DrawLine(new Vector3(_xBounds.x, _yBounds.y), new Vector3(_xBounds.x, _yBounds.x), color);    
    }
}
