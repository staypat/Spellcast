using UnityEngine;
using System.Collections.Generic;
using SerializeReferenceEditor;

public class ConditionalEffect : Effect
{
    public enum Condition
    {
        onlyCardOnPlate,
        aboveBread,
        aboveJam
    }
    [SerializeField] private Condition condition;
    [field: SerializeReference, SR] public Effect effectConditionNotMet { get; set; }
    [field: SerializeReference, SR] public Effect effectConditionMet { get; set; }

    public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
    {
        return GetGameAction(targets, caster, null);
    }
    public GameAction GetGameAction(List<CombatantView> targets, CombatantView caster, PlateView plate)
    {
        bool conditionMet = false;
        switch (condition)
        {
            case Condition.onlyCardOnPlate:
                conditionMet = plate.stack.Count == 1;
                break;
            case Condition.aboveBread:
                conditionMet = false;
                break;
            case Condition.aboveJam:
                conditionMet = false;
                break;
        }

        Effect chosenEffect = conditionMet ? effectConditionMet : effectConditionNotMet;
        return chosenEffect.GetGameAction(targets, caster);
    }
}
