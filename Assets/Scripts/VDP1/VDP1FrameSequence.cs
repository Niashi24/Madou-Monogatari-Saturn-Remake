using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "VDP1/Frame Sequence", fileName = "VDP1S_")]
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
    float fps = 60;
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

    [Button]
    void PopulateUsingVDP1Files(TextAsset[] frames)
    {
        _frames = new FrameData[frames.Length];
        string basePath = UnityEditor.AssetDatabase.GetAssetPath(this);
        Debug.Log(basePath);
        basePath = basePath[0..basePath.LastIndexOf('/')] + "/VDP1F_";
        for (int i = 0; i < frames.Length; i++)
        {
            VDP1Frame frame = ScriptableObject.CreateInstance<VDP1Frame>();
            frame.PopulateEntries(frames[i]);
            string path = basePath + frames[i].name + ".asset";
            // Debug.Log(path);
            UnityEditor.AssetDatabase.CreateAsset(frame, path);

            _frames[i] = new FrameData(){frame = frame};
        }
        
        
    }
    #endif
}
