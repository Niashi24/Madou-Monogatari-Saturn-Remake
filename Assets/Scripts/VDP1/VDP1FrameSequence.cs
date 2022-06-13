using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "VDP1/Frame Sequence")]
public class VDP1FrameSequence : ScriptableObject
{
    [System.Serializable]
    public class FrameData
    {
        public VDP1Frame frame;
        public int framesToPlay = 1;
    }

    [SerializeField]
    FrameData[] _frames;

    [SerializeField, Min(0.01f)]
    float fps = 10;
    public float FPS => fps;

    public FrameData[] Frames => _frames;

    public List<string> GetUniqueAddressesInSequence()
    {
        List<string> output = new();

        foreach (var frame in _frames)
            foreach (var entry in frame.frame.SpriteEntries)
                if (!output.Contains(entry.textureAddress))
                    output.Add(entry.textureAddress);

        return output;
    }

    #if UNITY_EDITOR
    [Button]
    void PopulateUsingVDP1Frames(VDP1Frame[] frames)
    {
        _frames = new FrameData[frames.Length];
        for (int i = 0; i < frames.Length; i++)
            _frames[i] = new FrameData(){frame = frames[i]};
    }
    #endif
}
