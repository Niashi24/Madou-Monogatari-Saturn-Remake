using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Character Growth")]
public class BattleCharacterGrowth : ScriptableObject
{
    [SerializeField]
    AnimationCurve _GCurve;
    
    [SerializeField]
    AnimationCurve _EXPCurve;

    [SerializeField]
    AnimationCurve _HPCurve;

    [SerializeField]
    AnimationCurve _ATKCurve;

    [SerializeField]
    AnimationCurve _DEFCurve;

    [SerializeField]
    AnimationCurve _SPDCurve;

    [SerializeField]
    AnimationCurve _ACCCurve;

    [SerializeField]
    AnimationCurve _LUCKCurve;

    public BattleStats GetStatsAtLevel(int level)
    {
        return new BattleStats()
        {
            LVL = 0,
            G = (int)_GCurve.Evaluate(level),
            EXP = (int)_EXPCurve.Evaluate(level),
            HP = (int)_HPCurve.Evaluate(level),
            ATK = (int)_ATKCurve.Evaluate(level),
            DEF = (int)_DEFCurve.Evaluate(level),
            SPD = (int)_SPDCurve.Evaluate(level),
            ACC = (int)_ACCCurve.Evaluate(level),
            LUCK = (int)_LUCKCurve.Evaluate(level),
        };
    }
}
