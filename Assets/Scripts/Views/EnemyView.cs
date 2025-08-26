using TMPro;
using UnityEngine;

public class EnemyView : CombatantView
{
    [SerializeField] private TMP_Text attackText;

    public int attackPower {  get; private set; }

    public void Setup(EnemyData enemyData)
    {
        attackPower = enemyData.attackPower;
        UpdateAttackText();
        SetupBase(enemyData.health, enemyData.image);
    }

    private void UpdateAttackText()
    {
        attackText.text = "ATK: " + attackPower;
    }
}
