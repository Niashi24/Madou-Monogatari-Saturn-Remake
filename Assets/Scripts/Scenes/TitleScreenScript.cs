using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class TitleScreenScript : MonoBehaviour
{
    [SerializeField]
    Image _actAgainstAIDSImage;

    [SerializeField]
    Image _adxImage;

    [SerializeField]
    Image _compileScreen;

    [SerializeField]
    Image _blueBackground;

    [SerializeField]
    Image _titleScreenLogo;

    [SerializeField]
    PlayBGM _bgmPlayer;

    [SerializeField]
    UnityEvent OnFinishLogoFade;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        yield return _actAgainstAIDSImage.DOFade(1f, 0.25f).WaitForCompletion();
        yield return new WaitForSeconds(1f);
        yield return _actAgainstAIDSImage.DOFade(0f, 0.25f).WaitForCompletion();
        yield return _adxImage.DOFade(1f, 0.25f).WaitForCompletion();
        yield return new WaitForSeconds(1f);
        yield return _adxImage.DOFade(0f, 0.25f).WaitForCompletion();
        yield return _compileScreen.DOFade(1f, 0.25f).WaitForCompletion();
        yield return new WaitForSeconds(3f);
        yield return _compileScreen.DOFade(0f, 0.25f).WaitForCompletion();
        yield return _blueBackground.DOFade(1f, 0.25f).WaitForCompletion();

        _bgmPlayer.Play();
        yield return _titleScreenLogo.DOFade(1f, 4f).WaitForCompletion();
        
        OnFinishLogoFade?.Invoke();
    }
}
