using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PhysicsM/Collision Layer")]
public class CollisionLayer : ScriptableObject
{
    [SerializeField] Color debugColor = Color.green;
    public Color DebugColor => debugColor;

    List<RectColliderBase> Objects;

    void OnEnable() {
        Objects = new();    
    }

    void OnDisable() {
        Objects = null;    
    }

    public void Add(RectColliderBase rectCollider)
    {
        if (!Objects.Contains(rectCollider))
            Objects.Add(rectCollider);
    }

    public void Remove(RectColliderBase rectCollider)
    {
        Objects.Remove(rectCollider);
    }

    public bool Intersects(RectColliderBase rectCollider)
    {
        foreach (var coll in Objects)
            if (coll.Intersects(rectCollider))
                return true;
        return false;
    }

    public bool Intersects(RectColliderBase original, out RectColliderBase intersected)
    {
        foreach (var coll in Objects)
        {
            if (coll.Intersects(original))
            {
                intersected = coll;
                return true;
            }
        }
        intersected = null;
        return false;
    }

    public List<RectColliderBase> IntersectsAll(RectColliderBase original)
    {
        var intersected = new List<RectColliderBase>();
        foreach (var coll in Objects)
        {
            if (coll.Intersects(original))
            {
                intersected.Add(coll);
            }
        }
        return intersected;
    }
}
