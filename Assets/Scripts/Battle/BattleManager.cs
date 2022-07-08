using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;
using System;

public class BattleManager : MonoSingleton<BattleManager>
{
    [SerializeField]
    SceneReference _battleScene;

    [SerializeField]
    BattleCharacterGrowth _growth;

    [SerializeField]
    ObjectValueReference<IBattlePlacer> _allyFormation;

    [SerializeField]
    ObjectValueReference<IBattlePlacer> _enemyFormation;

    [SerializeField]
    ObjectReference<IBattleMoveSelecter> _allyMoveSelecter;

    [SerializeField]
    ObjectReference<IBattleMoveSelecter> _enemyMoveSelecter;

    List<BattleUnit> AllyUnits, EnemyUnits;

    public BattleState State {get; private set;} = BattleState.Start;

    public void StartBattle(BattleParty allies, BattleParty enemies)
    {
        GameManager.I.ChangeState(GameState.Battle);
        
    }

    public IEnumerator DoBattle(BattleParty allies, BattleParty enemies)
    {
        // 1. set up battle
        //     - load battle party into battle units

        SetUpBattle(allies, enemies);

        // 2. get attacks from players
        //     -note: get all moves at once so can go back

        yield return _allyMoveSelecter.Value.EvaluateAttackSelecter();
        BattleAttack[] allyMoves = _allyMoveSelecter.Value.GetAttacks();

        // 3. get attacks from enemies
        //     -note: i guess it doesn't really matter when the enemy chooses for now
        //     -could get changed in the future
        
        yield return _enemyMoveSelecter.Value.EvaluateAttackSelecter();
        BattleAttack[] enemyMoves = _enemyMoveSelecter.Value.GetAttacks();

        // 4. sort all battle units by speed and evaluate all attacks from there
        //     -after each attack, check if battle is over (all players died, all enemies died)



        // 5. repeat at step 2
    }

    private void SetUpBattle(BattleParty allies, BattleParty enemies)
    {
        AllyUnits = _allyFormation.Value.PlaceCharacters(allies.Characters);
        EnemyUnits = _enemyFormation.Value.PlaceCharacters(enemies.Characters);
    }
}