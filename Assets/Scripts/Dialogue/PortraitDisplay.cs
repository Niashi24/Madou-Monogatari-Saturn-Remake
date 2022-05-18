using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitDisplay : MonoBehaviour
{
    [SerializeField]
    Image _portrait;
    [SerializeField]
    Image _portraitTick;

    public void SetPortrait(PortraitData portrait)
    {
        _portrait.sprite = portrait.Icon;
        _portraitTick.enabled = portrait.IsSpeaking;
    }
}
