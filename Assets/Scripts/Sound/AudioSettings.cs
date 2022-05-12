using UnityEngine;

[System.Serializable]
public class AudioSettings
{
    [SerializeField, Range(0,1)]
    float _sfxVolume;
    public float SFXVolume => _sfxVolume;

    [SerializeField, Range(0,1)]
    float _bgmVolume;
    public float BGMVolume => _bgmVolume;

    
    
}