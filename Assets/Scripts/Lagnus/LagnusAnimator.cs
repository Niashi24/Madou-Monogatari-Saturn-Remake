using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class LagnusAnimator : MonoBehaviour
{
    [SerializeField]
    LagnusMovement _player;

    [SerializeField]
    ValueReference<LagnusInput> _rawInput;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    SpriteRenderer _spriteRenderer;

    [SerializeField]
    Vector2 _initialDirection;

    Vector2 currentDirection;

    void Start() {
        currentDirection = _initialDirection;     
    }

    void LateUpdate()
    {
        if (_rawInput.Value.Direction != Vector2.zero)
            currentDirection = _rawInput.Value.Direction;

        var targetDirection = _player.Movement != Vector2.zero ? _player.Movement : currentDirection;

        _animator.SetFloat("X", targetDirection.x);
        _animator.SetFloat("Y", targetDirection.y);
        _animator.SetBool("Moving", _rawInput.Value.Moving);

        _spriteRenderer.flipX = targetDirection.x == 1;
    }

    public void SetDirection(Vector2 direction)
    {
        currentDirection = _initialDirection;
    }
}
