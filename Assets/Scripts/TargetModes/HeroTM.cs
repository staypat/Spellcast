using System.Collections.Generic;
using UnityEngine;

public class HeroTM : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        List<CombatantView> targets = new()
        {
            HeroSystem.Instance.heroView
        };
        return targets;
    }
}
