using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class PortraitData
{
    #if UNITY_EDITOR
    [ValueDropdown(nameof(Dropdown))]
    #endif
    
    [Required("Icon is required. Use \"None/None\" if you don't want a character icon.")]
    public Sprite Icon;

    public bool IsSpeaking;
    
    #if UNITY_EDITOR
    private ValueDropdownList<Sprite> Dropdown {get{
        ValueDropdownList<Sprite> output = new();

        string[] guids = AssetDatabase.FindAssets("t:CharacterPortraitEntry");

        CharacterPortraitEntry[] entries = new CharacterPortraitEntry[guids.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            entries[i] = AssetDatabase.LoadAssetAtPath<CharacterPortraitEntry>(AssetDatabase.GUIDToAssetPath(guids[i]));
        }

        foreach (var entry in entries)
        {
            foreach (var item in entry.Dropdown)
            {
                output.Add(new ValueDropdownItem<Sprite>($"{entry.name}/{item.Text}", item.Value));
            }
        }

        return output;
    }}
    #endif
}