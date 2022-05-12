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

    [SerializeField]
    CollisionLayer _obstacles;

    [SerializeField]
    CollisionLayer _interactables;

    public RectColliderManual Collider => _collider;

    public Vector2 Movement {get; private set;}

    public float LastHeldX {get; private set;} = 0;
    public float LastHeldY {get; private set;} = 0;

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

    private void Move()
    {
        var input = _input.Value;

        var direction = input.Direction;

        direction = GetNewDirection(this, direction);

        if (direction.x != 0) LastHeldX = direction.x;
        if (direction.y != 0) LastHeldY = direction.y;

        Debug.DrawRay(transform.position, direction * 30f, Color.green, 1 / 60f);

        transform.Translate(direction * _pixelsPerFrame.Value);
        Movement = direction;
    }

    Vector2 GetNewDirection(LagnusMovement player, Vector2 input)
    {
        float LastHeldX = input.x != 0 ? input.x : player.LastHeldX;
        float LastHeldY = input.y != 0 ? input.y : player.LastHeldY;

        bool IsDiagonal = input.sqrMagnitude == 2;

        if (WillIntersect(input, _interactables))
        {
            input = Vector2.zero;
            return input;
        }

        if (WillIntersect(input, _obstacles))
        {
            if (IsDiagonal) {
                Vector2 x = GetNewDirection(player, input.With(y:0));
                Vector2 y = GetNewDirection(player, input.With(x:0));
                input = new Vector2(x.x, y.y);
            } else if (input.x != 0)
                input = input.With(0, LastHeldY);
            else
                input = input.With(LastHeldX, 0);

            if (WillIntersect(input, _interactables))
                return Vector2.zero;
            if (WillIntersect(input, _obstacles))
            {
                if (!IsDiagonal)
                    input *= -1;

                if (WillIntersect(input, _obstacles) || WillIntersect(input, _interactables))
                    input = Vector2.zero;
                return input;
            }

            return input;
        }

        return input;
    }

    bool WillIntersect(Vector2 direction, CollisionLayer layer)
    {
        return WillIntersect(Collider, direction, _pixelsPerFrame.Value, layer);
    }

    bool WillIntersect(RectColliderManual coll, Vector2 direction, int pixels, CollisionLayer layer)
    {
        coll.transform.Translate(direction * pixels, Space.World);
        bool intersects = layer.Intersects(coll);
        coll.transform.Translate(direction * -pixels, Space.World);

        return intersects;
    }
}
