using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScenePortal : MonoBehaviour, IInteractable
{
    [SerializeField]
    [Required]
    SceneReference _scene;
    [Required]
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