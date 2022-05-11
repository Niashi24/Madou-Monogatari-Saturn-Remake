using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RigidbodyExtensions
{
    public static void Translate(this Rigidbody2D rbdy2D, Vector2 displacement)
    {
        rbdy2D.MovePosition(rbdy2D.position + displacement);
    }

    public static Vector2 With(this Vector2 original, float? x = null, float? y = null)
    {
        return new Vector2(
            x ?? original.x,
            y ?? original.y
        );
    }

    public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(
            x ?? original.x,
            y ?? original.y,
            z ?? original.z
        );
    }

    public static float Round(this float value, float unit)
    {
        return ((int)(value / unit)) * unit;
    }

    public static T Log<T>(this T subject)
    {
        Debug.Log(subject);
        return subject;
    }
}
