using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : SerializedMonoBehaviour
{
    [Header("Scene Objects")]
    [SerializeField]
    Dictionary<LanguageKey, BaseTextDisplay> _languageDisplay;

    [SerializeField]
    PortraitDisplay _leftPortrait;
    [SerializeField]
    PortraitDisplay _middlePortrait;
    [SerializeField]
    PortraitDisplay _rightPortrait;

    [SerializeField]
    BaseTextDisplay _defaultDisplay;

    [Header("Runtime Fields")]
    [SerializeField]
    LanguageKey _currentLanguage;

    [SerializeField]
    LocalizedPiece _currentPiece;

    float currentIndex = 0;

    public BaseTextDisplay CurrentDisplay => _languageDisplay.ContainsKey(_currentLanguage) ? _languageDisplay[_currentLanguage] : _defaultDisplay;

    public bool FinishedDisplaying {get; private set;} = true;

    string currentText = "";

    [Button]
    public void DisplayLocalizedText(LocalizedPiece textPiece, bool instant)
    {
        FinishedDisplaying = false;
        _currentPiece = textPiece;

        currentText = Sanitize(textPiece[_currentLanguage].Text);
        currentIndex = 0;
        SetPortraits(textPiece);

        if (instant)
        {
            CurrentDisplay.DisplayText(currentText);
            FinishedDisplaying = true;
            return;
        }
        //will type it in update
    }

    private string Sanitize(string str) {return str.Trim();}

    void SetPortraits(LocalizedPiece textPiece)
    {
        _leftPortrait.SetPortrait(textPiece.LeftPortrait);
        _middlePortrait.SetPortrait(textPiece.MiddlePortrait);
        _rightPortrait.SetPortrait(textPiece.RightPortrait);
    }

    void Update() {
        if (!FinishedDisplaying)
        {
            currentIndex += CurrentDisplay.CharactersPerSecond * Time.deltaTime;
            if (currentIndex >= currentText.Length)
            {
                FinishedDisplaying = true;
                CurrentDisplay.DisplayText(currentText);
                return;
            }
            else
            {
                CurrentDisplay.DisplayText(currentText[..(int)currentIndex]);
            }
        }    
    }

    [Button]
    public void ChangeLanguage(LanguageKey newLanguage)
    {
        if (_currentLanguage == newLanguage) return;

        _languageDisplay[_currentLanguage].gameObject.SetActive(false);
        _languageDisplay[newLanguage].gameObject.SetActive(true);

        _currentLanguage = newLanguage;

        DisplayLocalizedText(_currentPiece, false);
    }
}
