using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAttack
{
    public BattleStats Stats;
    public BattleMove Move;
    public BattleUnit Target;
    
    public IEnumerator PlayAnimation(BattleContext context)
    {
        yield return Move.PlayAnimation(this);
    }
}