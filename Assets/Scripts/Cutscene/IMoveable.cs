using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    IEnumerator Move(Vector3 target);
}
