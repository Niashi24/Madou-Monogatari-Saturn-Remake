using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioSource;

    [SerializeField]
    float _transitionTime;

    [ShowInInspector, ReadOnly]
    AudioData currentAudio;

    [ShowInInspector, ReadOnly]
    AudioData targetAudio;

    public void Play(AudioData s, bool instant)
    {

    }
}
