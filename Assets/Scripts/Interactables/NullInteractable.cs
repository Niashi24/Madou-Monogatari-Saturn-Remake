using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullInteractable : IInteractable
{
    public NullInteractable() {}

    readonly Object toLog = null;
    public NullInteractable(Object toLog)
    {
        this.toLog = toLog;
    }

    public void Interact()
    {
        if (toLog is null)
            Debug.LogWarning("Null Interaction!");
        else
            Debug.LogWarning($"Null Interaction with {toLog.name}!", toLog);
    }
}
