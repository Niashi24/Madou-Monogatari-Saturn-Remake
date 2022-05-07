using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;
using Sirenix.OdinInspector;

public class InteractHitbox : MonoBehaviour
{
    [SerializeField]
    [Required]
    RectColliderBase _interactHitbox;
    [SerializeField]
    [Required]
    LagnusMovement _player;
    [SerializeField]
    ValueReference<LagnusInput> _input;

    [SerializeField]
    float _distance;

    Vector2 currentDirection;

    void Update() {
        if (_input.Value.Direction != Vector2.zero)
            currentDirection = _input.Value.Direction;

        var targetDirection = _player.Movement != Vector2.zero ? _player.Movement : currentDirection;

        _interactHitbox.transform.localPosition = new Vector3(
            targetDirection.x * _distance,
            targetDirection.y * _distance,
            0
        );
    }
}
