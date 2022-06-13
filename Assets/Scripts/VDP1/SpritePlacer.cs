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

    ObjectPool<SpriteRenderer> spritePool;

    List<SpriteRenderer> activeSprites = new();

    [SerializeField]
    Vector3 _offset;
    
    [SerializeField]
    VDP1Frame _frame;

    void Start() {
        spritePool = new ObjectPool<SpriteRenderer>(
            () => {
                var gameObj = new GameObject("Sprite");
                gameObj.transform.parent = transform;
                gameObj.SetActive(false);
                return gameObj.AddComponent<SpriteRenderer>();
            },
            (x) => x.gameObject.SetActive(true),
            (x) => x.gameObject.SetActive(false),
            (x) => Destroy(x.gameObject)
        );    
    }

    public void PlaceFrame(VDP1Frame frame)
    {
        _frame = frame;
        PlaceCurrentFrame();
    }

    [DisableInEditorMode]
    [Button]
    public void PlaceCurrentFrame()
    {
        if (_frame is null) return;

        foreach (var renderer in activeSprites)
        {
            spritePool.Release(renderer);
        }
        activeSprites.Clear();

        for (int i = 0; i < _frame.SpriteEntries.Count; i++)
        {
            var entry = _frame.SpriteEntries[i];

            if (entry is ScaledSpriteEntry scaledSprite)
            {
                var sprite = GetSprite(scaledSprite.textureAddress);
                if (sprite is not null)
                {
                    PlaceSprite(sprite, scaledSprite.position, scaledSprite.reversed, i);
                }
            }
            else if (entry is DistortedSpriteEntry distortedSprite)
            {

            }
        }
    }

    void PlaceSprite(SpriteRenderer renderer, Vector2Int position, bool reversed, int num)
    {
        const float zGap = 0.01f; //Note: if there are more than 1000 sprites (unlikely) they might clip into the camera
        renderer.transform.localPosition = new Vector3(position.x, -position.y, num * -zGap) + _offset;
        renderer.flipX = reversed;
        renderer.sortingOrder = num;
        renderer.gameObject.SetActive(true);
    }

    Sprite GetSpriteFromAddress(string textureAddress)
    {
        if (_dict.addressSpriteDictionary.ContainsKey(textureAddress))
            return _dict.addressSpriteDictionary[textureAddress];
        return null;
    }

    SpriteRenderer GetSprite(string textureAddress)
    {
        if (_dict.addressSpriteDictionary.ContainsKey(textureAddress))
        {
            //get new renderer
            var renderer = spritePool.Get();
            renderer.sprite = _dict.addressSpriteDictionary[textureAddress];

            // currentSpritesDictionary.Add(textureAddress, renderer);

            activeSprites.Add(renderer);

            return renderer;
        }

        Debug.Log($"Missing texture: {textureAddress}");

        return null;
    }
}
