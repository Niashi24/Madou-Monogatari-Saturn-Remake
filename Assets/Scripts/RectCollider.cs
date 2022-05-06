using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class RectCollider : MonoBehaviour, IInteractable
{
    [SerializeField]
    Rect _rect;
    public Rect Rect => _rect;

    [SerializeField]
    CollisionLayer _layer;

    [SerializeField]
    Color _debugColor = Color.green;

    [SerializeField]
    List<ObjectReference<IInteractable>> _interactables;

    void OnDrawGizmos() {
        if (_layer is null)
            DebugDrawRect(this, _debugColor);
        else
            DebugDrawRect(this, _layer.DebugColor);
    }

    void OnEnable() {
        _layer?.Add(this);    
    }
     
    void OnDisable() {
        _layer?.Remove(this);    
    }

    public Vector2 TopLeft => 
        new Vector2(
            transform.position.x - _rect.width / 2 + _rect.position.x,
            transform.position.y + _rect.height / 2 + _rect.position.y
        );

    public Vector2 TopRight => TopLeft + Vector2.right * _rect.width;
    public Vector2 BottomLeft => TopLeft + Vector2.down * _rect.height;
    public Vector2 BottomRight => TopLeft + new Vector2(_rect.width, -_rect.height);

    public bool Intersects(RectCollider other)
    {
        var thisTopLeft = TopLeft;
        var otherTopLeft = other.TopLeft;

        return thisTopLeft.x < otherTopLeft.x + other.Rect.width &&
               thisTopLeft.x + Rect.width > otherTopLeft.x &&
               thisTopLeft.y - Rect.height < otherTopLeft.y &&
               thisTopLeft.y > otherTopLeft.y - other.Rect.height;
    }

    public IEnumerator Interact()
    {
        foreach (var interactable in _interactables)
        {
            yield return interactable;
        }
    }

    public static void DebugDrawRect(RectCollider rectCollider, Color color) 
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
