using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Audio Data")]
public class AudioData : ScriptableObject
{
    [SerializeField]
    AudioClip _audio;

    [SerializeField]
    float _volume = 1;

    [SerializeField]
    bool loop;
}