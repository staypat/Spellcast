using UnityEngine;

public class PlayCardGA : GameAction
{
    public Card card { get; set; }
    public EnemyView manualTarget { get; private set; }

    public PlayCardGA(Card card)
    {
        this.card = card;
        manualTarget = null;
    }

    public PlayCardGA(Card card, EnemyView target)
    {
        this.card = card;
        manualTarget = target;
    }
}
