using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
using UnitySceneManagement = UnityEngine.SceneManagement.SceneManager;

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
            
        if (UnitySceneManagement.GetActiveScene().buildIndex == 0)
            ChangeState(GameState.Title);
        else
            ChangeState(GameState.Overworld);
    }

    void OnDisable() {
        if (I.Equals(this))
            I = null;

        
    }

    [Button]
    public void ChangeState(GameState newState)
    {
        // Debug.Log($"State changed from {State} to {newState}");

        State = newState;

        // switch (State)
        // {
               
        // }

        OnStateChange?.Invoke(State);
    }
}
