using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Character Base")]
public class BattleCharacterBase : ScriptableObject
{
    [SerializeField]
    BattleStats _baseStats;
    public BattleStats Stats => _baseStats;
}