using System;
using System.Collections;
using System.Collections.Generic;
using LS.VDP1.Commands;
using LS.VDP1.Commands.Editor;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

public class SpritePlacer : MonoBehaviour
{
    [SerializeField]
    TextureDictionary _dict;

    [SerializeField]
    List<SpriteRenderer> currentSprites = new();
    
    [SerializeField]
    TextAsset _text;

    ObjectPool<SpriteRenderer> spritePool = new(
        () => {
            var gameObj = new GameObject("Sprite");
            return gameObj.AddComponent<SpriteRenderer>();
        },
        (x) => x.enabled = true,
        (x) => x.enabled = false,
        (x) => Destroy(x.gameObject)
    );

    [Button]
    public void PlaceSprites()
    {
        var commands = DrawCommandFactory.GetCommandsFromDebug(_text);

        currentSprites.ForEach(x => DestroyImmediate(x.gameObject));
        currentSprites.Clear();
        
        int i = 0;
        foreach (var command in commands)
        {
            if (command is ScaledSpriteCommand scaledSprite)
            {
                if (_dict.addressSpriteDictionary.ContainsKey(scaledSprite.textureAddress))
                {
                    var texture = _dict.addressSpriteDictionary[scaledSprite.textureAddress];
                    PlaceSprite(
                        texture,
                        scaledSprite,
                        i
                    );
                } else
                {
                    Debug.Log($"Missing texture: {scaledSprite.textureAddress}");
                }
            }
            i++;
        }
    }

    void PlaceSprite(Sprite texture, ScaledSpriteCommand scaledSprite, int num)
    {
        var gameObj = new GameObject(scaledSprite.textureAddress);
        gameObj.transform.parent = transform;
        var renderer = gameObj.AddComponent<SpriteRenderer>();
        currentSprites.Add(renderer);

        renderer.sprite = texture;
        renderer.transform.position = new Vector3(scaledSprite.xa, -scaledSprite.ya);
        renderer.flipX = scaledSprite.textureReadDirection != TextureReadDirection.Normal;
        renderer.sortingOrder = num;
        // throw new NotImplementedException();
    }
}
