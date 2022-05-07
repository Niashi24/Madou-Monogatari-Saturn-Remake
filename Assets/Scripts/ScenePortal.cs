using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScenePortal : MonoBehaviour
{
    [SerializeField]
    SceneReference _scene;

    [Button]
    public void TriggerTransition()
    {
        SceneManager.I.ChangeScene(_scene.ScenePath);
    }
}
