using System.Collections.Generic;
using UnityEngine;

public class RewardGenerator : MonoBehaviour
{
    [SerializeField] private List<CardUI> cardRewards;
    [SerializeField] private List<CardData> possibleCards;

    // TODO: Add logic for gold
    // TODO: Add logic for relics

    public void GenerateCardReward()
    {
        foreach (CardUI cardUI in cardRewards)
        {
            int randomIndex = Random.Range(0, possibleCards.Count);
            CardData randomCard = possibleCards[randomIndex];
            Card card = new(randomCard);
            cardUI.Setup(card);
        }
    }
}
