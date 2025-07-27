using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private readonly CardData cardData;
    public Card(CardData cardData)
    {
        this.cardData = cardData;
        effect = cardData.effect;
        cost = cardData.cost;
    }

    public Sprite sprite { get => cardData.sprite; }
    public string title { get => cardData.name; }
    public int cost { get; set; }
    public string effect { get; set; }

    public void PerformEffect()
    {
        Debug.Log(effect + " Performed & Cost of " + cost + " paid.");
    }
}
