using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Character")]
public class BattleCharacter : ScriptableObject
{
    [SerializeField]
    BattleCharacterBase _base;

    [SerializeField]
    BattleCharacterGrowth _growth;

    [SerializeField]
    int level;
    public int Level => level;

    // [SerializeField]
    [ShowInInspector, ReadOnly]
    public BattleStats GetBattleStats()
    {
        return _base.Stats + _growth.GetStatsAtLevel(level);
    }
}