using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using LS.Utilities;
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
    ValueReference<LanguageKey> _currentLanguage;

    [SerializeField]
    LocalizedPiece _currentPiece;

    float currentIndex = 0;

    public BaseTextDisplay CurrentDisplay => 
        _languageDisplay.ContainsKey(_currentLanguage.Value) ? _languageDisplay[_currentLanguage.Value] : _defaultDisplay;

    public bool FinishedDisplaying {get; private set;} = true;

    string currentText = "";

    void Start() {
        HideAllDisplays();
        _languageDisplay[_currentLanguage.Value].gameObject.SetActive(true);
    }

    [Button]
    public void DisplayLocalizedText(LocalizedPiece textPiece, bool instant)
    {
        if (!isActiveAndEnabled) return;

        FinishedDisplaying = false;
        _currentPiece = textPiece;

        currentText = Sanitize(textPiece[_currentLanguage.Value].Text);
        currentIndex = 0;
        SetPortraits(textPiece);

        CurrentDisplay.DisplayText("");

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

    private void HideAllDisplays()
    {
        foreach (var display in _languageDisplay.Values)
            display.gameObject.SetActive(false);
    }

    [Button]
    public void ChangeLanguage(LanguageKey newLanguage)
    {
        HideAllDisplays();
        _languageDisplay[newLanguage].gameObject.SetActive(true);

        if (_currentLanguage.Value != newLanguage)
            _currentLanguage.Value = newLanguage;

        DisplayLocalizedText(_currentPiece, false);
    }
}
