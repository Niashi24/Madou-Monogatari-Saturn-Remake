using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public class FrameSequencer : MonoBehaviour
{
    [SerializeField]
    ValueReference<VDP1FrameSequence> _frames;

    [SerializeField]
    VDP1Frame _stillFrame;

    [SerializeField]
    float secondsBetweenAnimations = 1;

    [SerializeField]
    SpritePlacer _placer;

    IEnumerator Start()
    {
        while (true) {
            yield return new WaitForSeconds(secondsBetweenAnimations);
            
            var anim = _frames.Value;
            var waitForNextAnimationFrame = new WaitForSeconds(1/anim.FPS);
            for (int i = 0; i < anim.Frames.Length; i++)
            {
                _placer.PlaceFrame(anim.Frames[i].frame);
                for (int j = 0; j < anim.Frames[i].framesToPlay; j++)
                    yield return waitForNextAnimationFrame;
            }
            _placer.PlaceFrame(_stillFrame);
        }
    }
}
