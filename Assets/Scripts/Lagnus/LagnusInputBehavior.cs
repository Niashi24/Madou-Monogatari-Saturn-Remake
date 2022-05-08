using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class LagnusInputBehavior : MonoBehaviour, IValueSupplier<LagnusInput>
{
    [SerializeField]
    ValueReference<LagnusInput> _input;

    LagnusInput currentInput;
    bool evaluatedInputThisFrame;

    void LateUpdate() {
        evaluatedInputThisFrame = false;
    }

    public LagnusInput Value {
        get
        {
            if (!evaluatedInputThisFrame)
            {
                currentInput = _input.Value;
                evaluatedInputThisFrame = true;
            }
            return currentInput;
        }
        set{}
    }
}
