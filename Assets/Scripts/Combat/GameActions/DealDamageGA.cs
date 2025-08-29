using System.Collections.Generic;
using UnityEngine;

public class DealDamageGA : GameAction
{
    public int amount { get; set; }
    public List<CombatantView> targets { get; set; }

    public DealDamageGA(int amount, List<CombatantView> targets)
    {
        this.amount = amount;
        this.targets = new(targets);
    }
}
