using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class TitleScreenScript : MonoBehaviour
{
    [SerializeField]
    [Required]
    Image _actAgainstAIDSImage;

    [SerializeField]
    [Required]
    Image _adxImage;

    [SerializeField]
    [Required]
    Image _compileScreen;

    [SerializeField]
    [Required]
    Image _blueBackground;

    [SerializeField]
    [Required]
    Image _titleScreenLogo;

    [SerializeField]
    [Required]
    PlayBGM _bgmPlayer;

    [SerializeField]
    [Required]
    ScenePortal _portal;

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

        while (!Input.GetKey(KeyCode.C))
            yield return null;

        _portal.TriggerTransition();
    }
}
