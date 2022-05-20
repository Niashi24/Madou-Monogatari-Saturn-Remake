using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

public class SetActiveIfLanguage : MonoBehaviour
{
    [SerializeField]
    GameObject _gameObject;

    [SerializeField]
    ValueReference<LanguageKey> _currentLanguague;

    [SerializeField]
    LanguageKey _language;

    [SerializeField]
    bool _active;

    void Start() {
        SetActive(_currentLanguague.Value);
    }

    public void SetActive(LanguageKey newLanguage)
    {
        _gameObject.SetActive(_language == newLanguage && _active);
    }
}
