using System.Collections;

public interface IBattleMoveSelecter
{
    IEnumerator EvaluateAttackSelecter();

    BattleAttack[] GetAttacks();
}