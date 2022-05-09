using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SceneEntrance : SerializedMonoBehaviour
{
    [SerializeField]
    Dictionary<SceneEntranceKey, SceneEntranceData> _dictionary = new();

    [SerializeField]
    LagnusAnimator _playerAnimator;

    public void LoadEntrance(SceneEntranceKey entranceKey)
    {
        if (!_dictionary.ContainsKey(entranceKey))
        {
            Debug.LogError($"No data for entrance key \"{entranceKey.name}\"");
            return;
        }
        var entranceData = _dictionary[entranceKey];
        _playerAnimator.transform.position = entranceData.SpawnPoint.position;

        _playerAnimator.SetDirection(entranceData.PlayerSpawnDirection);
    }
}
