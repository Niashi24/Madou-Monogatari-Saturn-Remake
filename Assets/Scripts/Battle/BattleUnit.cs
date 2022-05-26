using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    [SerializeField]
    protected BattleCharacter _character;
    
    [SerializeField]
    ObjectValueReference<IBattleAttackChooser> _attackChooser;
}
