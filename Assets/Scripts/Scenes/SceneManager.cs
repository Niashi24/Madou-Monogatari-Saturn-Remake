using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using DG.Tweening;
using Sirenix.OdinInspector;
using LS.Utilities;

public class SceneManager : MonoSingleton<SceneManager>
{
    [SerializeField]
    Image _blackScreen;
    [SerializeField]
    float _fadeTime = 0.5f;

    [SerializeField]
    ValueReference<bool> _isLoading;

    [Button]
    public void ChangeScene(string sceneName, SceneEntranceKey entranceKey)
    {
        if (_isLoading.Value) return;

        StartCoroutine(ChangeSceneCoroutine(sceneName, entranceKey));
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName, SceneEntranceKey entranceKey)
    {
        _isLoading.Value = true;

        yield return _blackScreen.DOFade(1f, _fadeTime).WaitForCompletion();

        yield return UnitySceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);

        var sceneEntrance = FindObjectOfType<SceneEntrance>();
        if (sceneEntrance is not null)
            sceneEntrance.LoadEntrance(entranceKey);

        yield return _blackScreen.DOFade(0f, _fadeTime).WaitForCompletion();

        _isLoading.Value = false;
    }
}
