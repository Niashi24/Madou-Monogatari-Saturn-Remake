using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScrollScript : MonoBehaviour
{
    [SerializeField]
    Vector3 targetPosition;

    [SerializeField]
    float _speed = 3.5f;

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
