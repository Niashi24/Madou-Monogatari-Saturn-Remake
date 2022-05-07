using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class RectColliderManual : RectColliderBase
{
    [SerializeField]
    Rect _rect;
    public override Rect Rect => _rect;
}
