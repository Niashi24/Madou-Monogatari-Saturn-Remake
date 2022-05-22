using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Handler/Lagnus Input/Navigation")]
public class LagnusNavigationInputHandler : ScriptableObject, IHandler<LagnusInput>
{
    private LagnusNavigation lagnusNavigation;

    public void Subscribe(LagnusNavigation navigation)
    {
        this.lagnusNavigation = navigation;
    }

    public LagnusInput Handle(LagnusInput input)
    {
        if (lagnusNavigation is null) return input;

        if (lagnusNavigation.IsCurrentlyNavigating)
        {
            input.Direction = lagnusNavigation.Direction;
            input.Moving = true;
            input.Interact = false;
        }

        return input;
    }
}
