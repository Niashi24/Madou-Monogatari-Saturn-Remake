using System.Collections;
using System.Collections.Generic;
using LS.SearchWindows;
using UnityEngine;

public class PlayDialogueAction : CutsceneAction
{
    [SerializeField]
    [AssetSearch]
    LocalizedPiece _dialogue;

    public override IEnumerator Execute(CutsceneContext context)
    {
        yield return DialogueManager.I.RunPiece(_dialogue);
    }
}
