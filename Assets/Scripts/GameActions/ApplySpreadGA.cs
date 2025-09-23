using UnityEngine;

public class ApplySpreadGA : GameAction
{
    public int damageAmount { get; private set; }
    public float spreadRatio { get; private set; }
    public EnemyView target { get; private set; }
    public ApplySpreadGA(int damageAmount, float spreadRatio, EnemyView target)
    {
        this.damageAmount = damageAmount;
        this.spreadRatio = spreadRatio;
        this.target = target;
    }
}
