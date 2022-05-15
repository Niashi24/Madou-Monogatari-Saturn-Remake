using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class StopBGM : MonoBehaviour
{
    [SerializeField]
    bool onStart;

    void Start() {
        if (onStart)
            Stop();    
    }

    public void Stop()
    {
        AudioManager.I.StopBGM();
    }
}
