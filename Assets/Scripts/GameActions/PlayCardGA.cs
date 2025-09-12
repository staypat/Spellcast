using UnityEngine;

public class PlayCardGA : GameAction
{
    public Card card { get; set; }
    public EnemyView target { get; private set; }

    public PlayCardGA(Card card)
    {
        this.card = card;
        target = null;
    }

    public PlayCardGA(Card card, EnemyView target)
    {
        this.card = card;
        this.target = target;
    }
}
