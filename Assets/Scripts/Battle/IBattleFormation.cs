using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleFormation
{
    void PlaceUnits(List<BattleUnit> characters);

    bool Applies(BattleContext context);
}
