using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PhysicsM/Collision Layer")]
public class CollisionLayer : ScriptableObject
{
    [SerializeField] Color debugColor = Color.green;
    public Color DebugColor => debugColor;

    List<RectCollider> Objects;

    void OnEnable() {
        Objects = new();    
    }

    void OnDisable() {
        Objects = null;    
    }

    public void Add(RectCollider rectCollider)
    {
        if (!Objects.Contains(rectCollider))
            Objects.Add(rectCollider);
    }

    public void Remove(RectCollider rectCollider)
    {
        Objects.Remove(rectCollider);
    }

    public bool Intersects(RectCollider rectCollider)
    {
        foreach (var coll in Objects)
            if (coll.Intersects(rectCollider))
                return true;
        return false;
    }

    public bool Intersects(RectCollider original, out RectCollider intersected)
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

    public List<RectCollider> IntersectsAll(RectCollider original)
    {
        var intersected = new List<RectCollider>();
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
