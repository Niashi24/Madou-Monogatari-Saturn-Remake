using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;


public class GoToBranch : CutsceneAction
{
    [SerializeField]
    ValueReference<bool> _predicate;

    [SerializeReference]
    CutsceneAction _false;

    [SerializeReference]
    CutsceneAction _true;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield break;
    }

    public override int GetNextActionIndex(CutsceneContext context)
    {
        return _predicate.Value ?
            _true.GetNextActionIndex(context) :
            _false.GetNextActionIndex(context);
    }
}
