using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ImageFadeAction : CutsceneAction
{
    [SerializeField]
    Image _image;
    [SerializeField]
    float _alpha;
    [SerializeField]
    float _seconds;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return _image.DOFade(_alpha, _seconds).WaitForCompletion();
    }
}
