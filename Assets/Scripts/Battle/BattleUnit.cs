using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    [SerializeField]
    protected BattleCharacter _character;

    public BattleCharacter Character => _character;

    public void Initialize(BattleCharacter character)
    {
        _character = character;
    }

    public void DealDamage(int damageDealt)
    {
        Character.DealDamage(damageDealt);

        //Display damage numbers

        //Display hurt animation
        
    }
}
