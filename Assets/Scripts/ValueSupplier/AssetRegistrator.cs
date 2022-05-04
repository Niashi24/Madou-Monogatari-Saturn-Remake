using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.SearchWindows;

public class AssetRegistrator<T> : MonoBehaviour
{
    [SerializeField]
    [AssetSearch]
    ValueAsset<T> _asset;

    [SerializeField]
    T _actor;

    void OnEnable() {
        _asset.Value = _actor;    
    }

    void OnDisable() {
        if (_asset.Value.Equals(_actor))
            _asset.Value = default;    
    }
}
