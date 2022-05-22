using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LagnusNavigation : MonoBehaviour, IMoveable
{
    public bool IsCurrentlyNavigating {get; private set;} = false;
    [ShowInInspector, ReadOnly]
    public Vector2 Direction {get; private set;}

    [SerializeField]
    LagnusNavigationInputHandler _navigationInputHandler;

    void OnEnable() {
        _navigationInputHandler.Subscribe(this);    
    }

    public IEnumerator Move(Vector3 target)
    {
        IsCurrentlyNavigating = true;

        var transform = this.transform;
        
        while ((transform.position - target).sqrMagnitude > 2)
        {
            Direction = target - transform.position;
            // Direction = Direction.With(y: -Direction.y);
            // Debug.Log($"{transform.position}, {target}");
            yield return null;
        }
        
        IsCurrentlyNavigating = false;
    }
}
