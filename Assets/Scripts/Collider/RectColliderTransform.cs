using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RectColliderTransform : RectColliderBase
{
    [SerializeField]
    private RectTransform _rect;

    public override Rect Rect {
        get
        {
            if (_rect is null)
                _rect = GetComponent<RectTransform>();
            var rect = _rect.rect;

            rect.x += rect.width / 2;
            rect.y += rect.height / 2;
            return rect;
        }
    }
}
