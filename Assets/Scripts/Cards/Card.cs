using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private readonly CardData cardData;
    public Sprite sprite { get => cardData.sprite; }
    public string title { get => cardData.name; }
    public string cardClass { get => cardData.cardClass; }
    public int cost { get; set; }
    public string effect { get; set; }

    public Card(CardData cardData)
    {
        this.cardData = cardData;
        cost = cardData.cost;
        effect = cardData.effect;
    }

    public void PerformEffect()
    {
        Debug.Log(effect + " Performed & Cost of " + cost + " paid.");
    }
}
