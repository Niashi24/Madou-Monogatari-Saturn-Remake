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
    public void ChangeScene(string sceneName, SceneEntranceKey entranceKey)
    {
        if (GameManager.I.State == GameState.Loading) return;

        StartCoroutine(ChangeSceneCoroutine(sceneName, entranceKey));
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName, SceneEntranceKey entranceKey)
    {
        var prevState = GameManager.I.State;
        GameManager.I.ChangeState(GameState.Loading);

        yield return _blackScreen.DOFade(1f, _fadeTime).WaitForCompletion();

        yield return UnitySceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        var sceneEntrance = FindObjectOfType<SceneEntrance>();
        if (sceneEntrance is not null)
            sceneEntrance.LoadEntrance(entranceKey);

        yield return _blackScreen.DOFade(0f, _fadeTime).WaitForCompletion();

        GameManager.I.ChangeState(prevState);
    }
}
