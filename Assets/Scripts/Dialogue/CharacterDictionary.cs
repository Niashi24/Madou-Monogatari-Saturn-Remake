using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Dialogue/Character Dictionary")]
public class CharacterDictionary : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<char, Sprite> dictionary;

    [SerializeField]
    [Tooltip("Default value to return when a character is missing from the dictionary.")]
    Sprite missingSprite;

    public Sprite this[char key]
    {
        get{
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            Debug.Log($"\"{(int)key}\"");
            return missingSprite;
        }
    }

    public Sprite[] TextToSprites(string text)
    {
        text = Sanitize(text);
        Sprite[] output = new Sprite[text.Length];
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = this[text[i]];
        }
        return output;
    }

    private string Sanitize(string str)
    {
        return str.Replace("\n", string.Empty).Replace(""+(char)13, string.Empty).Trim();
    }

    public bool ContainsCharacter(char key) => dictionary.ContainsKey(key);

    
    #if UNITY_EDITOR
    [Button]
    public void LoadDictionary(Object folder)
    {
        dictionary = new Dictionary<char, Sprite>();

        var folderPath = AssetDatabase.GetAssetPath(folder);

        var images = AssetDatabase.FindAssets("t:Sprite", new string[] {folderPath});

        foreach (var imgGUID in images)
        {
            var imgPath = AssetDatabase.GUIDToAssetPath(imgGUID);
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(imgPath);
            // Debug.Log(sprite);
            var name = GetFileName(imgPath);
            char key = name[0];
            
            if (dictionary.ContainsKey(key))
                Debug.LogWarning($"Duplicate Key: {key}");
            dictionary[key] = sprite;
        }
    }

    private string GetFileName(string pathName)
    {
        int nameStart = pathName.LastIndexOf('/') + 1;
        if (nameStart == 0) nameStart = 1;

        int typePeriod = pathName.LastIndexOf('.');
        if (typePeriod == 0) typePeriod = pathName.Length;

        return pathName[nameStart..typePeriod];
    }
    #endif
}
