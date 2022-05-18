using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRunner : MonoBehaviour
{
    [SerializeField]
    DialogueScript _script;

    [SerializeField]
    DialogueSystem _dialogueSystem;

    [SerializeField]
    KeyCode _confirmKey = KeyCode.Z;
    [SerializeField]
    KeyCode _skipKey = KeyCode.X;
    [SerializeField]
    KeyCode _holdSkipKey = KeyCode.C;

    private bool ConfirmPressed => Input.GetKeyDown(_confirmKey);
    private bool SkipHeld => Input.GetKey(_skipKey);
    private bool HoldSkipHeld => Input.GetKey(_holdSkipKey);

    IEnumerator Start() {
        while (true) {    
            yield return RunScript(_script);
        }    
    }

    public IEnumerator RunScript(DialogueScript script)
    {
        _dialogueSystem.gameObject.SetActive(true);
        foreach (var piece in script.Script)
        {
            yield return RunPiece(piece);
        }
        _dialogueSystem.gameObject.SetActive(false);
    }

    public IEnumerator RunPiece(LocalizedPiece piece)
    {
        _dialogueSystem.DisplayLocalizedText(piece, HoldSkipHeld || SkipHeld);
        while (!_dialogueSystem.FinishedDisplaying)
        {
            yield return null;
            if (SkipHeld || HoldSkipHeld)
                _dialogueSystem.DisplayLocalizedText(piece, true);
        }
        yield return null;
        yield return new WaitUntil(() => ConfirmPressed || HoldSkipHeld);
    }
}
