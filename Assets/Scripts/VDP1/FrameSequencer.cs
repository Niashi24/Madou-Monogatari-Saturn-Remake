using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSequencer : MonoBehaviour
{
    [SerializeField]
    List<VDP1Frame> frames = new();

    [SerializeField, Min(0.01f)]
    float fps;

    [SerializeField]
    SpritePlacer _placer;

    IEnumerator Start()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            for (int i = 0; i < frames.Count; i++)
            {
                _placer.PlaceFrame(frames[i]);
                yield return new WaitForSeconds(1/fps);
            }
        }
    }
}
