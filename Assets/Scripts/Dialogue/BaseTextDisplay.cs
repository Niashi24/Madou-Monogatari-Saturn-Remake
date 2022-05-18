using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTextDisplay : MonoBehaviour
{
    [SerializeField]
    protected float _charactersPerSecond = 60;
    public float CharactersPerSecond => _charactersPerSecond;

    public abstract void DisplayText(string text);
}
