using System.Collections;
using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

[CreateAssetMenu()]
public class LagnusPlayerInput : ScriptableObject, IValueSupplier<LagnusInput>
{
    [SerializeField]
    KeyCode _up = KeyCode.UpArrow;
    [SerializeField]
    KeyCode _right = KeyCode.RightArrow;
    [SerializeField]
    KeyCode _left = KeyCode.LeftArrow;
    [SerializeField]
    KeyCode _down = KeyCode.DownArrow;
    [SerializeField]
    KeyCode _interact = KeyCode.C;

    public LagnusInput Value
    {
        get
        {
            LagnusInput output = new LagnusInput();
            output.Left = Input.GetKey(_left);
            output.Right = Input.GetKey(_right);
            output.Down = Input.GetKey(_down);
            output.Up = Input.GetKey(_up);

            //direction might get zero'd so it wouldn't be moving so set it here
            //but in original even if there was no movement it would
            //still play the moving animations as long as
            //there was input
            output.Moving = output.Direction.sqrMagnitude != 0;

            output.Interact = Input.GetKeyDown(_interact);

            return output;
        }
        set{}
    }
}
