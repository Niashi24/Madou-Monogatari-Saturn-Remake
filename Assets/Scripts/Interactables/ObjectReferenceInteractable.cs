using LS.Utilities;
using UnityEngine;

[System.Serializable]
public class ObjectReferenceInteractable : IInteractable
{
    [SerializeField]
    ObjectReference<IInteractable> _interactable;

    public void Interact()
    {
        _interactable.Value.Interact();
    }
}