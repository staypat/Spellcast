using UnityEngine;

public class ApplyMeltGA : GameAction
{
    public int meltDamage { get; private set; }
    public CombatantView target { get; private set; }
    
    public ApplyMeltGA(int meltDamage, CombatantView target)
    {
        this.meltDamage = meltDamage;
        this.target = target;
    }
}
