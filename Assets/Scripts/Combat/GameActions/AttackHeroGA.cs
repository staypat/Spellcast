using UnityEngine;

public class AttackHeroGA : GameAction
{
    public EnemyView attacker {get; private set;}
    
    public AttackHeroGA(EnemyView attacker)
    {
        this.attacker = attacker;
    }
}
