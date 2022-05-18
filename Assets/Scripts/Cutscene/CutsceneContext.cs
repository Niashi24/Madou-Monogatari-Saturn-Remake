using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CutsceneContext
{
    public MonoBehaviour Controller;
    public List<CutsceneAction> actions;
    public int currentIndex;
}
