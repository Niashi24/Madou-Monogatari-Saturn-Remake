using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameState : CutsceneAction
{
    [SerializeField]
    GameState _newState;

    public override IEnumerator Execute(CutsceneContext context)
    {
        GameManager.I.ChangeState(_newState);
        yield break;
    }
}
