using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleAttackChooser
{
    IEnumerator ChooseAttack();

    BattleMove Move {get;}
}
