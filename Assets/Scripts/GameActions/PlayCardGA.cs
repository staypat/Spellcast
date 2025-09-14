using UnityEngine;

public class PlayCardGA : GameAction
{
    public Card card { get; set; }
    public PlateView plate { get; private set; }

    public PlayCardGA(Card card, PlateView plate)
    {
        this.card = card;
        this.plate = plate;
    }
}
