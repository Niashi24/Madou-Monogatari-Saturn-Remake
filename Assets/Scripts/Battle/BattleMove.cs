using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Move")]
public class BattleMove : ScriptableObject
{
    [SerializeField]
    GameObject _animationPrefab;
    public GameObject AnimationPrefab => _animationPrefab;

    [SerializeField]
    TargetType _targetType;
    public TargetType TargetType => _targetType;

    [SerializeField]
    int _baseATK;
    public int BaseATK => _baseATK;
    
    public IEnumerator PlayAnimation(BattleAttack context)
    {
        throw new NotImplementedException();
    }
}

public enum TargetType {Single, All}