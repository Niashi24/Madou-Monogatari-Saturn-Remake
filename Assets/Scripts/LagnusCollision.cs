using System.Collections;
using System.Collections.Generic;
using LS.SearchWindows;
using LS.Utilities;
using UnityEngine;

[CreateAssetMenu]
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
        var collider = player.Collider;

        if (WillIntersect(input.Direction, _interactables))
        {
            input.Direction = Vector2.zero;
            return input;
        }

        if (WillIntersect(input.Direction, _obstacles))
        {
            if (input.Direction.x != 0)
                input.Direction = input.Direction.With(0, player.LastHeldY);
            else
                input.Direction = input.Direction.With(player.LastHeldX, 0);

            if (WillIntersect(input.Direction, _interactables))
                return input;
            if (WillIntersect(input.Direction, _obstacles))
            {
                input.Direction *= -1;

                if (WillIntersect(input.Direction, _obstacles) || WillIntersect(input.Direction, _interactables))
                    input.Direction = Vector2.zero;
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

    bool WillIntersect(RectCollider coll, Vector2 direction, int pixels, CollisionLayer layer)
    {
        coll.transform.Translate(direction * pixels);
        bool intersects = layer.Intersects(coll);
        coll.transform.Translate(direction * -pixels);

        return intersects;
    }
}
