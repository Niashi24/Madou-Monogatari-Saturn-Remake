using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class LagnusInteractor : MonoBehaviour
{
    [SerializeField]
    [Required]
    RectColliderBase _interactHitbox;

    [SerializeField]
    [Required]
    CollisionLayer _interactablesLayer;

    [SerializeField]
    ValueReference<LagnusInput> _input;

    void Update() {
        if (_input.Value.Interact)
            Interact();
    }

    void Interact()
    {
        if (_interactablesLayer.Intersects(_interactHitbox, out var intersected))
        {
            intersected.Interactable.Interact();
        }
    }
}
