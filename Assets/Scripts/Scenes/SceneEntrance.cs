using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SceneEntrance : SerializedMonoBehaviour
{
    [SerializeField]
    Dictionary<SceneEntranceKey, SceneEntranceData> _dictionary = new();

    [SerializeField]
    SceneEntranceData _defaultEntranceData;

    [SerializeField]
    LagnusAnimator _playerAnimator;

    public void LoadEntrance(SceneEntranceKey entranceKey)
    {
        SceneEntranceData entranceData;
        if (entranceKey is not null && _dictionary.ContainsKey(entranceKey))
            entranceData = _dictionary[entranceKey];
        else
        {
            if (entranceKey is null)
                Debug.LogError("No entrance key.");
            else
                Debug.LogError($"No data for entrance key \"{entranceKey.name}\"");
            entranceData = _defaultEntranceData;
        }
        
        _playerAnimator.transform.position = entranceData.SpawnPoint.position;

        _playerAnimator.SetDirection(entranceData.PlayerSpawnDirection);
    }
}
