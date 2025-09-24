using System.Collections;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<PerformEffectGA>(PerformEffectPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<PerformEffectGA>();
    }

    private IEnumerator PerformEffectPerformer(PerformEffectGA performEffectGA)
    {
        if (performEffectGA.effect is ConditionalEffect conditionalEffect)
        {
            PlateView plate = performEffectGA.plate;
            GameAction effectAction = conditionalEffect.GetGameAction(performEffectGA.targets, HeroSystem.Instance.heroView, plate);
            ActionSystem.Instance.AddReaction(effectAction);
        }
        else
        {
            GameAction effectAction = performEffectGA.effect.GetGameAction(performEffectGA.targets, HeroSystem.Instance.heroView);
            ActionSystem.Instance.AddReaction(effectAction);
            yield return null;
        }
    }
}
