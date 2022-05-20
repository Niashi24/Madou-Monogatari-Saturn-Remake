using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    [SerializeField]
    SpriteRenderer _spriteRenderer;

    [SerializeField]
    bool _mirror;

    [SerializeField]
    Vector2 _initialDirection;

    void Start() {
        SetDirection(_initialDirection);
    }

    public void FaceObject(Transform other)
    {
        SetDirection(other.position - transform.position);
    }

    public void SetDirection(Vector2 direction)
    {
        direction.Normalize();
        _animator.SetFloat("X", direction.x);
        _animator.SetFloat("Y", direction.y);

        bool flip = direction.x >= 0;
        if (_mirror) flip = !flip;
        _spriteRenderer.flipX = flip;
    }
}
