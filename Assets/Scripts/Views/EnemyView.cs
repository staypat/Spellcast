using TMPro;
using UnityEngine;

public class EnemyView : CombatantView
{
    [SerializeField] private TMP_Text attackText;
    private EnemyBoardView enemyBoardView;

    public int attackPower { get; private set; }

    public void Setup(EnemyData enemyData)
    {
        attackPower = enemyData.attackPower;
        UpdateAttackText();
        SetupBase(enemyData.health, enemyData.image);
        enemyBoardView = FindFirstObjectByType<EnemyBoardView>();
    }

    private void UpdateAttackText()
    {
        attackText.text = "ATK: " + attackPower;
    }

    public override void Damage(int damageAmount)
    {
        base.Damage(damageAmount);
        if (GetStatusEffectStacks(StatusEffectType.SPREAD) > 0)
        {
            ApplySpreadGA applySpreadGA = new(damageAmount, 0.5f, this);
            ActionSystem.Instance.AddReaction(applySpreadGA);
        }
    }
}
