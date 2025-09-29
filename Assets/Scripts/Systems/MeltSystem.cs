using System.Collections;
using UnityEngine;

public class MeltSystem : MonoBehaviour
{
    [SerializeField] private GameObject meltVFX;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<ApplyMeltGA>(ApplyMeltPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<ApplyMeltGA>();
    }

    private IEnumerator ApplyMeltPerformer(ApplyMeltGA applyMeltGA)
    {
        CombatantView target = applyMeltGA.target;
        Instantiate(meltVFX, target.transform.position, Quaternion.identity);
        //DealDamageGA dealDamageGA = new(applyMeltGA.meltDamage, new() { target }, HeroSystem.Instance.heroView);
        //target.RemoveStatusEffect(StatusEffectType.MELT, 1);
        //ActionSystem.Instance.AddReaction(dealDamageGA);
        target.Damage(applyMeltGA.meltDamage);
        target.RemoveStatusEffect(StatusEffectType.MELT, 1);
        if (target.currentHealth <= 0 && target is EnemyView enemyView)
        {
            KillEnemyGA killEnemyGA = new(enemyView);
            ActionSystem.Instance.AddReaction(killEnemyGA);
        }
        yield return new WaitForSeconds(1f);
    }
}
