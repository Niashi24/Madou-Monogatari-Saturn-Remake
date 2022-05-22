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

    private AudioData currentBGM;

    [ShowInInspector, ReadOnly]
    public int runningSamples => _bgmSource.timeSamples;

    void Update() {
        HandleBGMLoop();    
    }

    private void HandleBGMLoop()
    {
        if (currentBGM is null) return;
        if (!currentBGM.Loop) return;

        if (_bgmSource.timeSamples > currentBGM.LoopEndSamples)
        {
            _bgmSource.timeSamples -= currentBGM.LoopLength;
            // Debug.Log("looped");
        } 
    }

    public void PlayBGM(AudioData bgm)
    {
        if (bgm.Equals(currentBGM)) return;
        
        currentBGM = bgm;
        UpdateSource(_bgmSource, currentBGM.Volume * _settings.Value.BGMVolume * _settings.Value.MasterVolume, currentBGM.Clip);
        _bgmSource.Play();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    public Coroutine FadeOutBGM(float seconds)
    {
        return StartCoroutine(FadeOutBGMCoroutine(seconds));
    }

    IEnumerator FadeOutBGMCoroutine(float seconds)
    {
        float timer = 0;
        float initialVolume = currentBGM.Volume * _settings.Value.BGMVolume * _settings.Value.MasterVolume;
        while (timer < seconds)
        {
            yield return null;
            timer += Time.deltaTime;

            float t = Mathf.Clamp01(timer / seconds);

            _bgmSource.volume = Mathf.Lerp(initialVolume, 0, t);
        }

        _bgmSource.volume = 0;
    }

    public void PlaySFX(AudioData sfx)
    {
        // UpdateSource(_sfxSource, sfx.Volume * _settings.Value.SFXVolume, sfx.Clip);
        _sfxSource.PlayOneShot(sfx.Clip, sfx.Volume * _settings.Value.SFXVolume * _settings.Value.MasterVolume);
    }

    public IEnumerator PlaySFXCoroutine(AudioData sfx)
    {
        _sfxSource.PlayOneShot(sfx.Clip, sfx.Volume * _settings.Value.SFXVolume * _settings.Value.MasterVolume);
        yield return new WaitForSeconds(sfx.Clip.length);
    }

    void UpdateSource(AudioSource source, float volume, AudioClip clip)
    {
        source.clip = clip;
        source.volume = volume;
    }
}
