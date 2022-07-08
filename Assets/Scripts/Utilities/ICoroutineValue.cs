using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoroutineValue<T>
{
    IEnumerator WaitForCoroutine();

    T Value {get;}
}