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
        target.Damage(applyMeltGA.meltDamage);
        target.RemoveStatusEffect(StatusEffectType.MELT, 1);
        yield return new WaitForSeconds(1f);
    }
}
