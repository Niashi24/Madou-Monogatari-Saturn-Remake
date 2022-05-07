using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour
    where T : MonoSingleton<T>
{
    private static T _instance;
    public static T I
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError(typeof(T).ToString() + " is missing.");
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Second instance of " + typeof(T) + " created. Automatic self-destruct triggered.");
            Destroy(this.gameObject);
        }
        _instance = this as T;

        Init();
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public virtual void Init() { }
}
