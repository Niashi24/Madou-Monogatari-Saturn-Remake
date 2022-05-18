using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SetLocationAction : CutsceneAction
{
    [SerializeField]
    GameObject _subject;

    [SerializeField]
    Vector3 _location;

    public override IEnumerator Execute(CutsceneContext context)
    {
        _subject.transform.position = _location;
        yield break;
    }
}
