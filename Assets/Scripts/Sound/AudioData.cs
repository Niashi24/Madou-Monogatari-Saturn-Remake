using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Audio/Audio Data")]
public class AudioData : ScriptableObject
{
    [SerializeField]
    AudioClip _audio;
    public AudioClip Clip => _audio;

    [SerializeField]
    float _volume = 1;
    public float Volume => _volume;

    [SerializeField]
    bool _loop;
    public bool Loop => _loop;

    [SerializeField]
    [ShowIf(nameof(_loop))]
    int _loopStartSamples;
    public int LoopStartSamples => _loopStartSamples;

    [SerializeField]
    [ShowIf(nameof(_loop))]
    int _loopEndSamples;
    public int LoopEndSamples => _loopEndSamples;

    public int LoopLength => LoopEndSamples - LoopStartSamples;
}