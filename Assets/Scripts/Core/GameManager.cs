using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public static GameManager I {get; private set;}

    [ShowInInspector, ReadOnly]
    public GameState State {get; private set;}

    public event Action<GameState> OnStateChange;

    void OnEnable() {
        if (I == null)
            I = this;
        else
            Destroy(gameObject);
            
        
    }

    void OnDisable() {
        if (I.Equals(this))
            I = null;

        
    }

    [Button]
    public void ChangeState(GameState newState)
    {
        State = newState;

        // switch (State)
        // {
               
        // }

        OnStateChange?.Invoke(State);
    }
}
