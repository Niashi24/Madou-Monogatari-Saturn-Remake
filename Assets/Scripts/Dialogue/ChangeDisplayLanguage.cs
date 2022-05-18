using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ChangeDisplayLanguage : MonoBehaviour
{
    [SerializeField]
    DialogueSystem _dialogueSystem;

    [SerializeField]
    LanguageKey _language;

    [Button]
    public void ChangeLanguage()
    {
        _dialogueSystem.ChangeLanguage(_language);
    }
}
