using System.Collections.Generic;
using UnityEngine;

public class Relic
{
    public Sprite image => data.image;
    private readonly RelicData data;
    private readonly RelicCondition condition;
    private readonly AutoTargetEffect effect;
    public Relic(RelicData relicData)
    {
        data = relicData;
        condition = data.condition;
        effect = data.autoTargetEffect;
    }

    public void OnAdd()
    {
        condition.SubscribeCondition(Reaction);
    }

    public void OnRemove()
    {
        condition.UnsubscribeCondition(Reaction);
    }

    private void Reaction(GameAction gameAction)
    {
        if (condition.SubConditionIsMet(gameAction))
        {
            List<CombatantView> targets = new();
            if (data.useActionCasterAsTarget && gameAction is IHaveCaster haveCaster)
            {
                targets.Add(haveCaster.caster);
            }
            if (data.useAutoTarget)
            {
                targets.AddRange(effect.targetMode.GetTargets());
            }
            GameAction relicEffectAction = effect.effect.GetGameAction(targets, HeroSystem.Instance.heroView);
            ActionSystem.Instance.AddReaction(relicEffectAction);
        }
    }
}
