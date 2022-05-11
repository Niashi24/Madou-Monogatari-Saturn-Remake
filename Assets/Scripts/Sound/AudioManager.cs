using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioPlayer _bgmAudioPlayer;

    [SerializeField]
    AudioPlayer _sfxAudioPlayer;

    [SerializeField]
    ValueReference<AudioSettings> _settings;
}
