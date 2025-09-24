using System.Collections.Generic;
using UnityEngine;

public class PerformEffectGA : GameAction
{
    public Effect effect {  get; set; }
    public List<CombatantView> targets { get; set; }
    public PlateView plate { get; set; }
    public PerformEffectGA(Effect effect, List<CombatantView> targets, PlateView plate)
    {
        this.effect = effect;
        this.targets = targets == null ? null : new(targets);
        this.plate = plate;
    }
}
