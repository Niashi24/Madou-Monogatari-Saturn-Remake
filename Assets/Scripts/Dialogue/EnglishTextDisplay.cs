using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class EnglishTextDisplay : BaseTextDisplay
{
    [SerializeField]
    Text _textBox;

    [Button]
    public override void DisplayText(string text)
    {
        _textBox.text = text;
    }
}
