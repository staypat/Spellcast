using System.Collections.Generic;
using UnityEngine;

public class AddStatusEffectGA : GameAction
{
    public StatusEffectType statusEffectType { get; private set; }
    public int stackCount { get; private set; }
    public List<CombatantView> targets { get; private set; }

    public AddStatusEffectGA(StatusEffectType statusEffectType, int stackCount, List<CombatantView> targets)
    {
        this.statusEffectType = statusEffectType;
        this.stackCount = stackCount;
        this.targets = targets;
    }
}
