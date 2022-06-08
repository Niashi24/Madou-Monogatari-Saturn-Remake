using System;
using UnityEngine;

namespace LS.Utilities
{
    [Serializable]
    /// Requires Unity 2020.1+
    public struct Optional<T>
    {
        [SerializeField] private bool enabled;
        [SerializeField] private T value;

        public bool Enabled => enabled;
        public T Value => value;

        public Optional(T initialValue)
        {
            enabled = true;
            value = initialValue;
        }
    }
}