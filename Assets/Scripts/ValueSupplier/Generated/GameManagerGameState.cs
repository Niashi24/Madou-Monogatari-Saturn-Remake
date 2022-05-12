using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Suppliers/GameState/GameManager State")]
public class GameManagerGameState : ScriptableObject, IValueSupplier<GameState>
{
    public GameState Value
    {
        get
        {
            if (GameManager.I is null) return default;
            return GameManager.I.State;
        }
        set
        {
            GameManager.I.ChangeState(value);
        }
    }
}
