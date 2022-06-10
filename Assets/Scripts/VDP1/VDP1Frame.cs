using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "VDP1/Frame Asset")]
public class VDP1Frame : ScriptableObject
{
    [SerializeField]
    List<SpriteEntry> spriteEntries = new();
    public List<SpriteEntry> SpriteEntries => spriteEntries;

    #if UNITY_EDITOR
    [Button]
    void PopulateEntries(TextAsset asset)
    {
        if (asset is null) return;
        spriteEntries.Clear();
        var commands = LS.VDP1.Commands.Editor.DrawCommandFactory.GetCommandsFromDebug(asset);
    
        foreach (var command in commands)
            if (command is LS.VDP1.Commands.ScaledSpriteCommand scaledSprite)
                spriteEntries.Add(new SpriteEntry() {
                    textureAddress = scaledSprite.textureAddress,
                    position = new(scaledSprite.xa, scaledSprite.ya),
                    reversed = scaledSprite.textureReadDirection != LS.VDP1.Commands.TextureReadDirection.Normal
                });
    }
    #endif
}
