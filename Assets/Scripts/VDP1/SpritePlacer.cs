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
    //each sprite is placed further in the back than the previous by this amount
    const float zGap = 0.01f;

    [SerializeField]
    TextureDictionary _dict;

    ObjectPool<SpriteRenderer> spritePool;

    [SerializeField]
    [Required]
    MeshCollector _meshCollectorPrefab;

    ObjectPool<MeshCollector> meshPool;

    List<SpriteRenderer> activeSprites = new();
    List<MeshCollector> activeMeshes = new();

    [SerializeField]
    Vector3 _offset;
    
    [SerializeField]
    VDP1Frame _frame;

    void Start() {
        spritePool = new ObjectPool<SpriteRenderer>(
            () => {
                var gameObj = new GameObject("Scaled Sprite");
                gameObj.transform.parent = transform;
                gameObj.SetActive(false);
                return gameObj.AddComponent<SpriteRenderer>();
            },
            (x) => x.gameObject.SetActive(true),
            (x) => x.gameObject.SetActive(false),
            (x) => Destroy(x.gameObject)
        );

        meshPool = new ObjectPool<MeshCollector>(
            () => {
                var meshCollector = Instantiate(
                    _meshCollectorPrefab,
                    Vector3.zero,
                    Quaternion.identity,
                    transform
                );

                meshCollector.name = "Distorted Sprite";

                return meshCollector;
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
            spritePool.Release(renderer);
        activeSprites.Clear();

        foreach (var mesh in activeMeshes)
            meshPool.Release(mesh);
        activeMeshes.Clear();

        for (int i = 0; i < _frame.SpriteEntries.Count; i++)
        {
            var entry = _frame.SpriteEntries[i];

            var sprite = GetSpriteFromAddress(entry.textureAddress);
            if (sprite is null)
            {
                Debug.LogError($"Missing texture: {entry.textureAddress}");
                continue;
            }
            if (entry is ScaledSpriteEntry scaledSprite)
            {
                //get new renderer
                var renderer = spritePool.Get();
                renderer.sprite = sprite;

                // currentSpritesDictionary.Add(textureAddress, renderer);

                activeSprites.Add(renderer);
                PlaceSprite(renderer, scaledSprite.position, scaledSprite.reversed, i);
            }
            else if (entry is DistortedSpriteEntry distortedSprite)
            {
                var meshCollector = meshPool.Get();
                activeMeshes.Add(meshCollector);

                meshCollector.transform.localPosition = new Vector3(0, 0, i * -zGap);

                meshCollector.UpdateMesh(distortedSprite.vertices, _offset, sprite);
            }
        }
    }

    void PlaceSprite(SpriteRenderer renderer, Vector2Int position, bool reversed, int num)
    {
        renderer.transform.localPosition = new Vector3(position.x, -position.y, num * -zGap) + _offset;
        renderer.flipX = reversed;
        renderer.sortingOrder = num;
        renderer.gameObject.SetActive(true);
    }

    void PlaceDistortedSprite(MeshCollector meshCollector)
    {

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
