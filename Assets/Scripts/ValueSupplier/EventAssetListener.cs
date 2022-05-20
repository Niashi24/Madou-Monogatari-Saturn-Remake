using System.Collections;
using System.Collections.Generic;
using LS.SearchWindows;
using UnityEngine;
using UnityEngine.Events;

public class EventAssetListener<T> : MonoBehaviour
{
    [SerializeField]
    [AssetSearch]
    EventAsset<T> _eventAsset;

    [SerializeField]
    UnityEvent<T> _onTriggerEvent;

    void OnEnable() {
        _eventAsset.Event += TriggerEvent;    
    }

    void OnDisable() {
        _eventAsset.Event -= TriggerEvent;    
    }

    void TriggerEvent(T value)
    {
        if (_onTriggerEvent is not null)
            _onTriggerEvent.Invoke(value);
    }
}
