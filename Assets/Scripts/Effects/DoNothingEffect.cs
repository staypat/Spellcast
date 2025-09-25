using System.Collections.Generic;
using UnityEngine;

public class DoNothingEffect : Effect
{
    public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
    {
        return new DoNothingGA();
    }
}
