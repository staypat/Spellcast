using UnityEngine;
using System.Collections;

public class SpreadSystem : MonoBehaviour
{
    [SerializeField] private EnemyBoardView enemyBoardView;
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<ApplySpreadGA>(ApplySpreadPerformer);
    }
    private void OnDisable()
    {
        ActionSystem.DetachPerformer<ApplySpreadGA>();
    }
    private IEnumerator ApplySpreadPerformer(ApplySpreadGA applySpreadGA)
    {
        int damageAmount = applySpreadGA.damageAmount;
        float spreadRatio = applySpreadGA.spreadRatio;
        int spreadDamage = (int)(damageAmount * spreadRatio);
        EnemyView target = applySpreadGA.target;
        if (spreadDamage <= 0)
        {
            yield break;
        }
        enemyBoardView.GetAdjacentEnemies(target, out EnemyView leftEnemy, out EnemyView rightEnemy);
        if (leftEnemy != null)
        {
            leftEnemy.Damage(spreadDamage);
            yield return new WaitForSeconds(0.5f);
        }
        if (rightEnemy != null)
        {
            rightEnemy.Damage(spreadDamage);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}
