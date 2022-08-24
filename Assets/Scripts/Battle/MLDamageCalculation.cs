public class MLDamageCalculation : IDamageCalculation
{
    public int CalculateDamage(BattleUnit target, BattleAttack attack)
    {
        var TargetStats = target.Character.GetBattleStats();
        var AttackStats = attack.Stats;
        
        return AttackStats.ATK * AttackStats.LVL * attack.Move.AttackConstant / TargetStats.DEF;
    }
}