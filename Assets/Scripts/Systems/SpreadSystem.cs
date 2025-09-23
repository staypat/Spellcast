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
        EnemyView target = applySpreadGA.target;
        enemyBoardView.GetAdjacentEnemies(target, out EnemyView leftEnemy, out EnemyView rightEnemy);
        if (leftEnemy != null)
        {
            leftEnemy.Damage((int)(damageAmount * spreadRatio));
            yield return new WaitForSeconds(0.5f);
        }
        if (rightEnemy != null)
        {
            rightEnemy.Damage((int)(damageAmount * spreadRatio));
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}
