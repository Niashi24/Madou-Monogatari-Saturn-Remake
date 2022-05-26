using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Utilities;

public class BattleManager : MonoSingleton<BattleManager>
{
    [SerializeField]
    SceneReference _battleScene;

    [SerializeField]
    BattleCharacterGrowth _growth;

    [SerializeField]
    ObjectValueReference<IBattleFormation> _allyFormation;

    [SerializeField]
    ObjectValueReference<IBattleFormation> _enemyFormation;

    public BattleState State {get; private set;} = BattleState.Start;

    public void StartBattle(BattleParty allies, BattleParty enemies)
    {
        GameManager.I.ChangeState(GameState.Battle);

    }

    
}
