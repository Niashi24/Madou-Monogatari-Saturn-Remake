using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public struct LagnusInput
{
    public bool Left, Right, Up, Down;
    
    public bool Interact;

    [ShowInInspector, ReadOnly, HideLabel]
    public Vector2 Direction 
    {
        get
        {
            int x = 0;
            if (Left) x--;
            if (Right) x++;

            int y = 0;
            if (Up) y++;
            if (Down) y--;

            return new Vector2(x, y);
        }
        set
        {
            Left = value.x == -1;
            Right = value.x == 1;
            Up = value.y == 1;
            Down = value.y == -1;
        }
    }
}
