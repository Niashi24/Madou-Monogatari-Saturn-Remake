using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "VDP1/Frame Sequence")]
public class VDP1FrameSequence : ScriptableObject
{
    [SerializeField]
    VDP1Frame[] _frames;

    public VDP1Frame[] Frames => _frames;

    public List<string> GetUniqueAddressesInSequence()
    {
        List<string> output = new();

        foreach (var frame in _frames)
            foreach (var entry in frame.SpriteEntries)
                if (!output.Contains(entry.textureAddress))
                    output.Add(entry.textureAddress);

        return output;
    }
}
