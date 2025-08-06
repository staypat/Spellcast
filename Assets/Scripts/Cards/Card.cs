using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string title { get => cardData.name; }
    public string cardClass { get => cardData.cardClass; }
    public Sprite sprite { get => cardData.sprite; }
    public int cost { get; set; }
    public string effect { get; set; }

    private readonly CardData cardData;

    public Card(CardData cardData)
    {
        this.cardData = cardData;
        cost = cardData.cost;
        effect = cardData.description;
    }

    public void PerformEffect()
    {
        Debug.Log(effect + " Performed & Cost of " + cost + " paid.");
    }
}
