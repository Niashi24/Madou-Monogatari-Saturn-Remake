using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    [SerializeField]
    DialogueSystem _dialogueSystem;

    [SerializeField]
    KeyCode _confirmKey = KeyCode.Z;
    [SerializeField]
    KeyCode _skipKey = KeyCode.X;
    [SerializeField]
    KeyCode _holdSkipKey = KeyCode.C;

    public bool Running {get; private set;} = false;

    private bool ConfirmPressed => Input.GetKeyDown(_confirmKey);
    private bool SkipHeld => Input.GetKey(_skipKey);
    private bool HoldSkipHeld => Input.GetKey(_holdSkipKey);

    public IEnumerator RunPiece(LocalizedPiece piece)
    {
        if (Running)
        {
            Debug.LogWarning($"Tried to run a piece of dialogue when already running: {piece}", this);
            yield break;
        }
        
        Running = true;
        _dialogueSystem.gameObject.SetActive(true);

        _dialogueSystem.DisplayLocalizedText(piece, HoldSkipHeld || SkipHeld);
        while (!_dialogueSystem.FinishedDisplaying)
        {
            yield return null;
            if (SkipHeld || HoldSkipHeld)
                _dialogueSystem.DisplayLocalizedText(piece, true);
        }
        yield return null;
        yield return new WaitUntil(() => ConfirmPressed || HoldSkipHeld);
        
        _dialogueSystem.gameObject.SetActive(true);
        Running = false;
    }
}
