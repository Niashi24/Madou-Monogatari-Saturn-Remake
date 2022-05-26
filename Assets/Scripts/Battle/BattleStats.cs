using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BattleStats
{
    public int LVL;
    public int G;
    public int EXP;
    public int HP;
    public int ATK;
    public int DEF;
    public int SPD;
    public int ACC;
    public int LUCK;

    public static BattleStats operator +(BattleStats a, BattleStats b)
    {
        return new BattleStats()
        {
            LVL = a.LVL + b.LVL,
            G = a.G + b.G,
            EXP = a.EXP + b.EXP,
            HP = a.HP + b.HP,
            ATK = a.ATK + b.ATK,
            DEF = a.DEF + b.DEF,
            SPD = a.SPD + b.SPD,
            ACC = a.ACC + b.ACC,
            LUCK = a.LUCK + b.LUCK
        };
    }
}