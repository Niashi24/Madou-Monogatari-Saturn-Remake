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

    private void OnDrawGizmosSelected() {
        var width = _rect.rect.width;
        var height = _rect.rect.height;

        float x = transform.position.x;
        float y = transform.position.y;

        transform.position = transform.position.With(
            x: width % 4 == 0 ? x.Round(2) : x.Round(2) + (x > 0 ? 1 : -1),
            y: height % 4 == 0 ? y.Round(2) : y.Round(2) + (y > 0 ? 1 : -1),
            z: transform.position.z
        );
    }
}
