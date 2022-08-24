using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;
using System.Linq;
using Sirenix.OdinInspector;

public class BattleManager : MonoSingleton<BattleManager>
{
    [SerializeReference]
    [Required]
    IBattlePlacer _allyFormation;

    [SerializeReference]
    [Required]
    IBattlePlacer _enemyFormation;

    [SerializeReference]
    [Required]
    IBattleMoveSelecter _allyMoveSelecter;

    [SerializeReference]
    [Required]
    IBattleMoveSelecter _enemyMoveSelecter;

    [SerializeReference]
    [Required]
    IDamageCalculation _damageCalculator;

    List<BattleUnit> AllyUnits, EnemyUnits;

    public BattleContext CurrentContext {get; private set;} = new();

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

        yield return _allyMoveSelecter.EvaluateAttackSelecter();
        BattleAttack[] allyMoves = _allyMoveSelecter.GetAttacks();

        // 3. get attacks from enemies
        //     -note: i guess it doesn't really matter when the enemy chooses for now
        //     -could get changed in the future
        
        yield return _enemyMoveSelecter.EvaluateAttackSelecter();
        BattleAttack[] enemyMoves = _enemyMoveSelecter.GetAttacks();

        // 4. sort all battle units by speed and evaluate all attacks from there
        //     -after each attack, check if battle is over (all players died, all enemies died)

        var ActiveMoves = Join(allyMoves, enemyMoves).OrderBy(x => x.Stats.SPD).ToArray();

        foreach (var move in ActiveMoves)
        {
            move.PlayAnimation(CurrentContext);
            foreach (var target in move.Targets)
            {
                int damageDealt = _damageCalculator.CalculateDamage(target, move);
                target.DealDamage(damageDealt);
            }
            //Wait for hit animation

            //Check if any are dead
                //if so, play death animation
            
            //Check if all are dead
                //if so, end battle
        }

        // 5. repeat at step 2
    }

    private BattleAttack[] Join(BattleAttack[] a, BattleAttack[] b)
    {
        BattleAttack[] joined = new BattleAttack[a.Length + b.Length];

        for (int i = 0; i < a.Length; i++)
            joined[i] = a[i];

        for (int i = 0; i < b.Length; i++)
            joined[i+a.Length] = b[i];

        return joined;
    }

    private void SetUpBattle(BattleParty allies, BattleParty enemies)
    {
        AllyUnits = _allyFormation.PlaceCharacters(allies.Characters);
        EnemyUnits = _enemyFormation.PlaceCharacters(enemies.Characters);

        CurrentContext.allies = AllyUnits;
        CurrentContext.enemies = EnemyUnits;
    }
}
