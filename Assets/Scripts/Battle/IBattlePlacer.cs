using System.Collections.Generic;

public interface IBattlePlacer
{
    List<BattleUnit> PlaceCharacters(List<BattleCharacter> characters);
}
