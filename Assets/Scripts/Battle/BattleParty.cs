using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Party")]
public class BattleParty : ScriptableObject
{
    public List<BattleCharacter> Characters;
}