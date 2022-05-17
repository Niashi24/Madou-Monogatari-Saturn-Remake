using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAction : CutsceneAction
{
    [SerializeField]
    GameObject _subject;

    [SerializeField]
    bool _active;

    public override IEnumerator Execute(CutsceneContext context)
    {
        _subject.SetActive(_active);
        yield break;
    }
}
