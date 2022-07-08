using System.Collections;
using UnityEngine;

public interface ICutsceneRunner
{
    void StopCutscene();

    Coroutine StartCoroutine(IEnumerator routine);
}