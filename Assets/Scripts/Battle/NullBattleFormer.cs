using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullBattleFormer : IBattleFormation
{
    public bool Applies(BattleContext context)
    {
        return true;
    }

    public void PlaceUnits(List<BattleUnit> characters)
    {
        Debug.LogError("No formation found!");
    }
}
