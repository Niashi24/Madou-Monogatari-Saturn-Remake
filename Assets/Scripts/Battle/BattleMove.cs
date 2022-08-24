using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Move")]
public abstract class BattleMove : ScriptableObject
{
    [SerializeField]
    GameObject _animationPrefab;
    public GameObject AnimationPrefab => _animationPrefab;

    [SerializeField]
    TargetType _targetType;
    public TargetType TargetType => _targetType;

    [SerializeField, Tooltip("Base attack constant for how much damage the move does.")]
    int _attackConstant;
    public int AttackConstant => _attackConstant;
    
    public IEnumerator PlayAnimation(BattleAttack context)
    {
        throw new NotImplementedException();
    }

    public abstract IEnumerator DoAffect(BattleAttack context);
}

public enum TargetType {Single, All}