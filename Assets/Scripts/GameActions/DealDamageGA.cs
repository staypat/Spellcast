using System.Collections.Generic;
using UnityEngine;

public class DealDamageGA : GameAction, IHaveCaster
{
    public int amount { get; set; }
    public List<CombatantView> targets { get; set; }
    public CombatantView caster { get; private set; }

    public DealDamageGA(int amount, List<CombatantView> targets, CombatantView caster)
    {
        this.amount = amount;
        this.targets = new(targets);
        this.caster = caster;
    }
}
