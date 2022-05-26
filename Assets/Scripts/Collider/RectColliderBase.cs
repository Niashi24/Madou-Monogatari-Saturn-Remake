using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public abstract class RectColliderBase : MonoBehaviour
{
    public abstract Rect Rect {get;}

    [SerializeField]
    CollisionLayer _layer;

    [SerializeField]
    Color _debugColor = Color.green;

    [SerializeField]
    ObjectReference<IInteractable> _interactable;
    public IInteractable Interactable => _interactable.HasValue ? _interactable.Value : new NullInteractable(this);

    void OnDrawGizmos() {
        if (!isActiveAndEnabled) return;
        
        if (_layer is null)
            DebugDrawRect(this, _debugColor);
        else
            DebugDrawRect(this, _layer.DebugColor);
    }

    void OnEnable() {
        if (_layer is not null)
            _layer.Add(this);
    }
     
    void OnDisable() {
        if (_layer is not null)
            _layer.Remove(this);
    }

    public Vector2 TopLeft => 
        new(
            transform.position.x - Rect.width / 2 + Rect.position.x,
            transform.position.y + Rect.height / 2 + Rect.position.y
        );

    public Vector2 TopRight => TopLeft + Vector2.right * Rect.width;
    public Vector2 BottomLeft => TopLeft + Vector2.down * Rect.height;
    public Vector2 BottomRight => TopLeft + new Vector2(Rect.width, -Rect.height);

    public bool Intersects(RectColliderBase other)
    {
        var thisTopLeft = TopLeft;
        var otherTopLeft = other.TopLeft;

        return thisTopLeft.x < otherTopLeft.x + other.Rect.width &&
               thisTopLeft.x + Rect.width > otherTopLeft.x &&
               thisTopLeft.y - Rect.height < otherTopLeft.y &&
               thisTopLeft.y > otherTopLeft.y - other.Rect.height;
    }

    public static void DebugDrawRect(RectColliderBase rectCollider, Color color) 
    {
        Debug.DrawLine(rectCollider.TopLeft, rectCollider.TopRight, color);
        Debug.DrawLine(rectCollider.TopRight, rectCollider.BottomRight, color);
        Debug.DrawLine(rectCollider.BottomRight, rectCollider.BottomLeft, color);
        Debug.DrawLine(rectCollider.TopLeft, rectCollider.BottomLeft, color);
    }

    public static void DebugDrawRect(Vector2 origin, Rect rect, Color color)
    {
        var topLeft = new Vector2(
            origin.x - rect.width / 2 + rect.position.x,
            origin.y + rect.height / 2 + rect.position.y
        );

        var topRight = topLeft + Vector2.right * rect.width;
        var bottomLeft = topLeft + Vector2.down * rect.height;
        var bottomRight = topLeft + new Vector2(rect.width, -rect.height);

        Debug.DrawLine(topLeft, topRight, color);
        Debug.DrawLine(topRight, bottomRight, color);
        Debug.DrawLine(bottomRight, bottomLeft, color);
        Debug.DrawLine(topLeft, bottomLeft, color);
    }
}
