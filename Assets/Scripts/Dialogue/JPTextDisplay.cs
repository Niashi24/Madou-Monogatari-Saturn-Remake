using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class JPTextDisplay : BaseTextDisplay
{
    [Header("Dictionary")]
    [SerializeField]
    Sprite blankCharacter;

    [SerializeField]
    CharacterDictionary japaneseDictionary;

    [Header("UI Components")]
    [SerializeField]
    [TableMatrix]
    Image[] characterDisplays;

    Sprite[] currentText;

    [PropertySpace]
    [Button]
    public override void DisplayText(string text)
    {
        ResetDisplay();
        currentText = japaneseDictionary.TextToSprites(text);
        for (int i = 0; i < currentText.Length && i < characterDisplays.Length; i++)
        {
            characterDisplays[i].sprite = currentText[i];
        }
    }

    public void ResetDisplay()
    {
        for (int i = 0; i < characterDisplays.Length; i++)
        {
            characterDisplays[i].sprite = blankCharacter;
        }
    }

    #if UNITY_EDITOR
    [Button]
    public void InitializeImages(Image sourceObject)
    {
        characterDisplays = new Image[18 * 3];
        var rectTransform = GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        Vector3 topLeft = corners[1];
        // foreach (var corner in corners)
        //     Debug.DrawLine(transform.position, corner, Color.green, 5f);
        // return;
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 18; x++)
            {
                characterDisplays[y * 18 + x] = Instantiate<Image>(
                    sourceObject,
                    new Vector3(
                        topLeft.x + x * 16 * 2,
                        topLeft.y - y * 16 * 2,
                        0
                    ),
                    Quaternion.identity,
                    transform
                );
                characterDisplays[y * 18 + x].gameObject.name = $"img_{y+1}_{x+1}";
            }
        }
    }
    #endif
}
