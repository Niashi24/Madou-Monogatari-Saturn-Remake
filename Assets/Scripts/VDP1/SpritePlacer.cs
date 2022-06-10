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
    VDP1Frame _frame;

    [Button]
    public void PlaceSprites()
    {
        if (_frame is null) return;

        foreach (var renderer in currentSpritesDictionary.Values)
        {
            renderer.gameObject.SetActive(false);
        }

        for (int i = 0; i < _frame.SpriteEntries.Count; i++)
        {
            var entry = _frame.SpriteEntries[i];
            var sprite = GetSprite(entry.textureAddress);
            if (sprite is not null)
            {
                PlaceSprite(sprite, entry.position, entry.reversed, i);
            }
        }
    }

    void PlaceSprite(SpriteRenderer renderer, Vector2Int position, bool reversed, int num)
    {
        renderer.transform.localPosition = new Vector3(position.x, -position.y) + _offset;
        renderer.flipX = reversed;
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
