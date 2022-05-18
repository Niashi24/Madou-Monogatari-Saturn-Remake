using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogueAction : CutsceneAction
{
    [SerializeField]
    LocalizedPiece _dialogue;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return DialogueManager.I.RunPiece(_dialogue);
    }
}
