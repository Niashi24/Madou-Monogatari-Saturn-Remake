using System;
using System.Collections;
using System.Collections.Generic;
using LS.VDP1.Commands;
using LS.VDP1.Commands.Editor;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

public class SpritePlacer : SerializedMonoBehaviour
{
    [SerializeField]
    TextureDictionary _dict;

    [SerializeField]
    Dictionary<string, SpriteRenderer> currentSpritesDictionary = new();
    
    [SerializeField]
    TextAsset _text;

    [Button]
    public void PlaceSprites()
    {
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
        renderer.transform.position = new Vector3(scaledSprite.xa, -scaledSprite.ya);
        renderer.flipX = scaledSprite.textureReadDirection != TextureReadDirection.Normal;
        renderer.sortingOrder = num;
        renderer.gameObject.SetActive(true);
        // throw new NotImplementedException();
    }

    SpriteRenderer GetSprite(string textureAddress)
    {
        if (currentSpritesDictionary.ContainsKey(textureAddress))
            return currentSpritesDictionary[textureAddress];
        //not loaded
        if (_dict.addressSpriteDictionary.ContainsKey(textureAddress))
        {
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
