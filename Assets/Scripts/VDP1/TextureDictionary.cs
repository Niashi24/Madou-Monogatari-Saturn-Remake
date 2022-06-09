using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "VDP1/Texture Dictionary")]
public class TextureDictionary : SerializedScriptableObject
{
    public Dictionary<string, Sprite> addressSpriteDictionary = new();

    [Button]
    public void AddSpriteUsingName(Sprite newSprite)
    {
        if (!addressSpriteDictionary.ContainsKey(newSprite.name))
            addressSpriteDictionary.Add(newSprite.name, newSprite);
    }

    [Button]
    public void AddSpritesUsingName(Sprite[] newSprites)
    {
        foreach (var newSprite in newSprites)
            AddSpriteUsingName(newSprite);
    }

    #if UNITY_EDITOR
    [Button]
    void FindAndLoadAllTextures()
    {
        var images = UnityEditor.AssetDatabase.FindAssets("t:Sprite 000");

        foreach (var imgGUID in images)
        {
            var imgPath = UnityEditor.AssetDatabase.GUIDToAssetPath(imgGUID);
            var sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(imgPath);
            
            AddSpriteUsingName(sprite);
        }
    }
    #endif
}
