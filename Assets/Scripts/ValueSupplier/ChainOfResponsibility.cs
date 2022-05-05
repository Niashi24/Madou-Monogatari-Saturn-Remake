using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class ChainOfResponsibility<T> : ScriptableObject, IValueSupplier<T>
{
    [SerializeField]
    protected ObjectReference<IHandler<T>>[] handlers;

    [SerializeField]
    protected ValueReference<T> initialState;

    public T Value {
        get
        {
            var output = initialState.Value;

            foreach (var handler in handlers)
                output = handler.Value.Handle(output);

            return output;
        }
        set{}
    }
}
