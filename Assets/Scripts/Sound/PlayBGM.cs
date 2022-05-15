using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField]
    AudioData _bgm;

    [SerializeField]
    bool _onStart;

    void Start() {
        if (_onStart)
            Play();    
    }

    public void Play()
    {
        AudioManager.I.PlayBGM(_bgm);
    }
}
