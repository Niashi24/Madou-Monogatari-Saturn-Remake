using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class TextPiece
{
    private const int JPLineLimit = 18;
    private const int LatinLineLimit = 41;

    [SerializeField]
    [TextArea(3, 10)]
    [ValidateInput(nameof(IsCorrectLength), "Must be 3 lines, 18 characters each line.")]
    [ValidateInput(nameof(IsTooLong), "Characters per line is too much, will cause wrapping.")]
    [ValidateInput(nameof(HasTooManyLines), "Cannot be more than 3 lines.")]
    string text;

    [SerializeField]
    bool isJapanese;

    public string Text => text;

    private bool IsCorrectLength()
    {
        if (text is null) return true;
        if (!isJapanese) return true;

        foreach (var line in text.Split('\n'))
        {
            if (line.Length != JPLineLimit && line.Length != JPLineLimit + 1)
                return false;
        }
        return true;
    }

    private bool IsTooLong()
    {
        if (isJapanese) return true;
        if (text is null) return true;

        foreach (var line in text.Split('\n'))
        {
            if (line.Length > LatinLineLimit)
                return false;
        }
        return true;
    }

    private bool HasTooManyLines()
    {
        if (text is null) return true;
        return text.Split('\n').Length <= 3;
    }
}