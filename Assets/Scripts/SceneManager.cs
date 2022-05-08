using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using DG.Tweening;
using Sirenix.OdinInspector;

public class SceneManager : MonoSingleton<SceneManager>
{
    [SerializeField]
    Image _blackScreen;
    [SerializeField]
    float _fadeTime = 0.5f;

    [Button]
    public void ChangeScene(string sceneName)
    {
        if (GameManager.I.State == GameState.Loading) return;

        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        var prevState = GameManager.I.State;
        GameManager.I.ChangeState(GameState.Loading);

        yield return _blackScreen.DOFade(1f, _fadeTime).WaitForCompletion();

        yield return UnitySceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);

        yield return _blackScreen.DOFade(0f, _fadeTime).WaitForCompletion();

        GameManager.I.ChangeState(prevState);
    }
}
