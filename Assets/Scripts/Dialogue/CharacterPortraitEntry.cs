using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/Portrait/Character Entry")]
public class CharacterPortraitEntry : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<string, Sprite> entries;

    public ValueDropdownList<Sprite> Dropdown => GetList();

    ValueDropdownList<Sprite> GetList()
    {
        ValueDropdownList<Sprite> output = new ValueDropdownList<Sprite>();

        foreach (var (key, item) in entries)
            output.Add(new ValueDropdownItem<Sprite>(key, item));
        
        return output;
    }
}