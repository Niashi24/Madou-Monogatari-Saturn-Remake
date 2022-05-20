using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField]
    ValueReference<LanguageKey> _currentLanguageReference;

    [SerializeField]
    LanguageKey[] _languages;

    [SerializeField]
    KeyCode _changeLanguageKey = KeyCode.F12;

    int currentIndex = 0;

    void Start() {
        if (_languages is null) Debug.LogError("No languages set");
        if (_languages.Length == 0) Debug.LogError("No languages set");

        int defaultIndex = -1;
        for (int i = 0; i < _languages.Length; i++)
        {
            if (_languages[i].Equals(_currentLanguageReference.Value))
            {
                defaultIndex = i;
                break;
            }
        }

        currentIndex = defaultIndex;
    }

    void Update() {
        if (_languages is null) return;
        if (_languages.Length == 0) return;

        if (Input.GetKeyDown(_changeLanguageKey))
        {
            currentIndex = (currentIndex + 1) % _languages.Length;
            _currentLanguageReference.Value = _languages[currentIndex];
        }
    }
}
