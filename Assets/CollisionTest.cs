using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField]
    Collider2D ours;

    [SerializeField]
    Collider2D theirs;

    void OnDrawGizmos() {
        if (ours is null || theirs is null) return;

        Debug.DrawLine(ours.transform.position, theirs.transform.position, ours.IsTouching(theirs) ? Color.red : Color.green);    
    }
}
