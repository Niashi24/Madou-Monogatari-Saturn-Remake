using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Handler/Lagnus Input/Game State")]
public class LagnusInputStateHandler : ScriptableObject, IHandler<LagnusInput>
{
    [SerializeField]
    List<GameState> _validStates = new List<GameState>();

    [SerializeField]
    ValueReference<GameState> _currentState;

    public LagnusInput Handle(LagnusInput input)
    {
        if (_validStates.Contains(_currentState.Value))
            return input;

        input.Direction = Vector2.zero;
        input.Moving = false;
        input.Interact = false;

        return input;
    }
}
