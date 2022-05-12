using System;
using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField]
    [Required]
    AudioSource _sfxSource;

    [SerializeField]
    [Required]
    AudioSource _bgmSource;

    [SerializeField]
    ValueReference<AudioSettings> _settings;

    [SerializeField]
    AudioData _initialBGM;

    private AudioData currentBGM;

    [ShowInInspector, ReadOnly]
    public int runningSamples => _bgmSource.timeSamples;

    void Start() 
    {
        PlayBGM(_initialBGM);
    }

    void Update() {
        HandleBGMLoop();    
    }

    private void HandleBGMLoop()
    {
        if (!currentBGM.Loop) return;

        if (_bgmSource.timeSamples > currentBGM.LoopEndSamples)
        {
            _bgmSource.timeSamples -= currentBGM.LoopLength;
            Debug.Log("looped");
        }
    }

    void PlayBGM(AudioData bgm)
    {
        if (bgm.Equals(currentBGM)) return;
        
        currentBGM = bgm;
        UpdateSource(_bgmSource, currentBGM.Volume * _settings.Value.BGMVolume * _settings.Value.MasterVolume, currentBGM.Clip);
        _bgmSource.Play();
    }

    public void PlaySFX(AudioData sfx)
    {
        // UpdateSource(_sfxSource, sfx.Volume * _settings.Value.SFXVolume, sfx.Clip);
        _sfxSource.PlayOneShot(sfx.Clip, sfx.Volume * _settings.Value.SFXVolume * _settings.Value.MasterVolume);
    }

    void UpdateSource(AudioSource source, float volume, AudioClip clip)
    {
        source.clip = clip;
        source.volume = volume;
    }
}
