using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoToLabelAction : CutsceneAction
{
    [SerializeField]
    string name;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield break;
    }

    public override int GetNextActionIndex(CutsceneContext context)
    {
        var index = context.actions.FindIndex(isGoToLabel);
        if (index != -1) return index;
        return base.GetNextActionIndex(context);
    }

    private bool isGoToLabel(CutsceneAction action)
    {
        if (action is LabelAction label)
            return label.Name == name;
        return false;
    }
}
