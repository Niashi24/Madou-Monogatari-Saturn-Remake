using System.Collections.Generic;
using LS.Utilities;
using UnityEngine;

[System.Serializable]
public class ObjectBattlePlacer : IBattlePlacer
{
    [SerializeField]
    ObjectReference<IBattlePlacer> _battlePlacer;

    public List<BattleUnit> PlaceCharacters(List<BattleCharacter> characters)
        => _battlePlacer.Value.PlaceCharacters(characters);
}