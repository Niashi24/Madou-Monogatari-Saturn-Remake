using System.Collections;
using LS.Utilities;
using UnityEngine;

public class ObjectReferenceBattleMoveSelecter : IBattleMoveSelecter
{
    [SerializeField]
    ObjectReference<IBattleMoveSelecter> _battleMoveSelecter;

    public IEnumerator EvaluateAttackSelecter()
        => _battleMoveSelecter.Value.EvaluateAttackSelecter();

    public BattleAttack[] GetAttacks()
        => _battleMoveSelecter.Value.GetAttacks();
}