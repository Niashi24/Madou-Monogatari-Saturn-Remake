using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelAction : CutsceneAction
{
    [SerializeField]
    string _name;

    public string Name => _name;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield break;
    }
}
