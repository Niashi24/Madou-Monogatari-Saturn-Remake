using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTransitionManager : MonoSingleton<BattleTransitionManager>
{
    [SerializeField]
    SceneReference _battleScene;

    public void StartBattle(BattleParty allies, BattleParty enemies)
    {
        
    }
}
