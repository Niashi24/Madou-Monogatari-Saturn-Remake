using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections;

[CreateAssetMenu(menuName = "Dialogue/Localized Piece")]
public class LocalizedPiece : SerializedScriptableObject
{

    [SerializeField]
    PortraitData _leftPortrait;

    [SerializeField]
    PortraitData _middlePortrait;

    [SerializeField]
    PortraitData _rightPortrait;

    [SerializeField]
    [Required]
    Dictionary<LanguageKey, TextPiece> text = new();

    public TextPiece this[LanguageKey key]
    {
        get 
        {
            if (text.ContainsKey(key))
                return text[key];
            return null;
        }
    }

    public PortraitData LeftPortrait => _leftPortrait;
    public PortraitData MiddlePortrait => _middlePortrait;
    public PortraitData RightPortrait => _rightPortrait;
}
