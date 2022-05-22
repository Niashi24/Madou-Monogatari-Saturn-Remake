using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAction : CutsceneAction
{
    [SerializeField]
    Object _context;

    [SerializeField]
    string message;

    public override IEnumerator Execute(CutsceneContext context)
    {
        if (_context is not null)
            Debug.Log(message, _context);
        else
            Debug.Log(message);
        yield break;
    }
}
