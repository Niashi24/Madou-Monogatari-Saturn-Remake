using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField]
    AudioData _sfx;

    public void Play()
    {
        AudioManager.I.PlaySFX(_sfx);
    }
}
