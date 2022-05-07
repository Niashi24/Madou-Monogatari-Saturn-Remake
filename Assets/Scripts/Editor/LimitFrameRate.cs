using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LimitFrameRate
{
    [MenuItem("Tools/Frame Rate/Limit")]
    public static void Limit()
    {
        Application.targetFrameRate = 60;
    }

    [MenuItem("Tools/Frame Rate/Reset")]
    public static void Reset()
    {
        Application.targetFrameRate = -1;
    }
}
