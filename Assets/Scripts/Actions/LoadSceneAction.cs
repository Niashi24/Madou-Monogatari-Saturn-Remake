using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneAction : CutsceneAction
{
    [SerializeField]
    SceneReference _scene;
    [SerializeField]
    SceneEntranceKey _entranceKey;

    public override IEnumerator Execute(CutsceneContext context)
    {
        SceneManager.I.ChangeScene(_scene.ScenePath, _entranceKey);
        yield break;
    }
}
