using System.Collections;
using System.Collections.Generic;
using LS.SearchWindows;
using LS.Utilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Handler/Lagnus Input/Collision")]
public class LagnusCollision : ScriptableObject, IHandler<LagnusInput>
{
    [SerializeField]
    [AssetSearch]
    ValueAsset<LagnusMovement> _player;
    [SerializeField]
    ValueReference<int> _pixelsPerFrame;

    [SerializeField]
    CollisionLayer _obstacles;
    [SerializeField]
    CollisionLayer _interactables;

    public LagnusInput Handle(LagnusInput input)
    {
        if (_player is null) return input;
        if (_player.Value is null) return input;
        if (_interactables is null || _obstacles is null) return input;

        var player = _player.Value;
        // var collider = player.Collider;

        input.Direction = GetNewDirection(player, input.Direction);


        return input;
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
        return WillIntersect(_player.Value.Collider, direction, _pixelsPerFrame.Value, layer);
    }

    bool WillIntersect(RectColliderManual coll, Vector2 direction, int pixels, CollisionLayer layer)
    {
        coll.transform.Translate(direction * pixels, Space.World);
        bool intersects = layer.Intersects(coll);
        coll.transform.Translate(direction * -pixels, Space.World);

        return intersects;
    }
}
