using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAsset<T> : ScriptableObject
{
    public event Action<T> Event;

    public void Invoke(T value)
    {
        Event?.Invoke(value);
    }
}
