using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

[System.Serializable]
public class SceneEntranceData
{
    [SerializeField]
    Transform _spawnPoint;
    public Transform SpawnPoint => _spawnPoint;

    [SerializeField]
    Vector2 _playerSpawnDirection;
    public Vector2 PlayerSpawnDirection => _playerSpawnDirection;

    [SerializeField]
    public UnityEvent<SceneEntranceData> OnUseEntrance = new();
}