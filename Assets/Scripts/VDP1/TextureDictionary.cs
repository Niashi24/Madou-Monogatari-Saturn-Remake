using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "VDP1/Texture Dictionary")]
public class TextureDictionary : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<string, Sprite> addressSpriteDictionary = new();

    
}
