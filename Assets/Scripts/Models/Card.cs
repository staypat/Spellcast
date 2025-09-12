using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string title => cardData.name; 
    public string description => cardData.description;
    public string cardClass => cardData.cardClass; 
    public Sprite sprite => cardData.sprite;
    public List<Effect> delayedEffects => cardData.delayedEffects;
    public List<AutoTargetEffect> instantEffects => cardData.instantEffects;
    public int cost { get; set; }

    private readonly CardData cardData;

    public Card(CardData cardData)
    {
        this.cardData = cardData;
        cost = cardData.cost;
    }
}
