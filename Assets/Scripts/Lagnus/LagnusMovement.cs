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
    RectColliderManual _collider;

    public RectColliderManual Collider => _collider;

    public Vector2 Movement {get; private set;}

    public float LastHeldX {get; private set;} = 0;
    public float LastHeldY {get; private set;} = 0;

    WaitForSeconds WaitAFrame = new WaitForSeconds(1f/60);

    const float waitTime = 1f/60;
    float timer = 0;

    void Update() {
        timer += Time.deltaTime;
        while (timer >= waitTime)
        {
            Move();
            timer -= waitTime;
        }
    }

    // IEnumerator Start()
    // {
    //     while (enabled)
    //     {
    //         yield return WaitAFrame;
    //         Move();
    //     }

    //     yield break;
    // }

    private void Move()
    {
        var input = _input.Value;

        var direction = input.Direction;

        if (direction.x != 0) LastHeldX = direction.x;
        if (direction.y != 0) LastHeldY = direction.y;

        Debug.DrawRay(transform.position, direction * 30f, Color.green, 1 / 60f);

        transform.Translate(direction * _pixelsPerFrame.Value);
        Movement = direction;
    }
}
