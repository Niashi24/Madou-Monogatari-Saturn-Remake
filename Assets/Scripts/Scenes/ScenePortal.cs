using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScenePortal : MonoBehaviour, IInteractable
{
    [SerializeField]
    [Required]
    SceneReference _scene;
    [ValidateInput("@_entranceKey != null", "No entrance key set. Will go to default location", InfoMessageType.Warning)]
    [SerializeField]
    SceneEntranceKey _entranceKey;

    [Button]
    [DisableInEditorMode]
    public void TriggerTransition()
    {
        SceneManager.I.ChangeScene(_scene.ScenePath, _entranceKey);
    }

    public void Interact() 
    {
        if (enabled)
            TriggerTransition();
    }
}