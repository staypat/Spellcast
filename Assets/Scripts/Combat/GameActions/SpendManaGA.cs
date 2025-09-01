using UnityEngine;

public class SpendManaGA : GameAction
{
    public int amount { get; set; }

    public SpendManaGA(int amount)
    {
        this.amount = amount;
    }
}
