using System.Collections;
using System.Collections.Generic;
using LS.VDP1.Commands;
using LS.VDP1.Commands.Editor;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

[SelectionBase]
public class SpritePlacer : SerializedMonoBehaviour
{
    [SerializeField]
    TextureDictionary _dict;

    [SerializeField]
    Dictionary<string, SpriteRenderer> currentSpritesDictionary = new();

    [SerializeField]
    [OnValueChanged(nameof(PlaceSprites))]
    Vector3 _offset;
    
    [SerializeField]
    [OnValueChanged(nameof(PlaceSprites))]
    TextAsset _text;

    [Button]
    public void PlaceSprites()
    {
        if (_text is null) return;
        var commands = DrawCommandFactory.GetCommandsFromDebug(_text);

        foreach (var renderer in currentSpritesDictionary.Values)
        {
            renderer.gameObject.SetActive(false);
        }

        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i] is ScaledSpriteCommand scaledSprite)
            {
                var sprite = GetSprite(scaledSprite.textureAddress);
                if (sprite is not null)
                {
                    PlaceSprite(sprite, scaledSprite, i);
                }
            }
        }
    }

    void PlaceSprite(SpriteRenderer renderer, ScaledSpriteCommand scaledSprite, int num)
    {
        renderer.transform.localPosition = new Vector3(scaledSprite.xa, -scaledSprite.ya) + _offset;
        renderer.flipX = scaledSprite.textureReadDirection != TextureReadDirection.Normal;
        renderer.sortingOrder = num;
        renderer.gameObject.SetActive(true);
    }

    SpriteRenderer GetSprite(string textureAddress)
    {
        if (currentSpritesDictionary.ContainsKey(textureAddress))
            return currentSpritesDictionary[textureAddress];

        //doesn't already have a sprite loaded
        if (_dict.addressSpriteDictionary.ContainsKey(textureAddress))
        {
            //create new renderer
            var gameObj = new GameObject(textureAddress);
            gameObj.transform.parent = transform;
            var renderer = gameObj.AddComponent<SpriteRenderer>();
            renderer.sprite = _dict.addressSpriteDictionary[textureAddress];

            currentSpritesDictionary.Add(textureAddress, renderer);

            return renderer;
        }

        Debug.Log($"Missing texture: {textureAddress}");

        return null;
    }
}
