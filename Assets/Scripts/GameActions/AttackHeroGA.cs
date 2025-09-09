using UnityEngine;

public class AttackHeroGA : GameAction, IHaveCaster
{
    public EnemyView attacker {get; private set;}
    public CombatantView caster { get; private set;}
    
    public AttackHeroGA(EnemyView attacker)
    {
        this.attacker = attacker;
        caster = attacker;
    }
}
