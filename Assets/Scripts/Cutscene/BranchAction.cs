using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public class BranchAction : CutsceneAction
{
    [SerializeField]
    ValueReference<bool> _predicate;

    [SerializeReference]
    CutsceneAction _false;

    [SerializeReference]
    CutsceneAction _true;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return _predicate.Value ? _true.Execute(context) : _false.Execute(context);
    }
}
