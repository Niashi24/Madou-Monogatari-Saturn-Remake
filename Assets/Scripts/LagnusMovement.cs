using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class LagnusMovement : MonoBehaviour
{
    [SerializeField]
    ValueReference<LagnusInput> _input;

    [SerializeField]
    ValueReference<int> _pixelsPerFrame;

    [SerializeField]
    RectCollider _collider;

    public RectCollider Collider => _collider;

    public Vector2 Movement {get; private set;}

    public float LastHeldX {get; private set;} = 0;
    public float LastHeldY {get; private set;} = 0;

    WaitForSeconds WaitAFrame = new WaitForSeconds(1f/60);

    IEnumerator Start()
    {
        while (enabled)
        {
            yield return WaitAFrame;

            var input = _input.Value;

            var direction = input.Direction;

            if (direction.x != 0) LastHeldX = direction.x;
            if (direction.y != 0) LastHeldY = direction.y;

            Debug.DrawRay(transform.position, direction * 30f, Color.green, 1/60f);

            transform.Translate(direction * _pixelsPerFrame.Value);
        }

        yield break;
    }
}
