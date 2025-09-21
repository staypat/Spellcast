using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardGenerator : MonoBehaviour
{
    [SerializeField] private List<CardUI> cardRewards;
    [SerializeField] private List<CardData> possibleCards;
    private CardData selectedCard;

    // TODO: Add logic for gold
    // TODO: Add logic for relics

    public void GenerateCardReward()
    {
        List<CardData> cardsChosenAlready = new List<CardData>(); // holds list of cards that were generated as rewards
        foreach (CardUI cardUI in cardRewards)
        {
            CardData randomCard;
            // keeps picking a random card until it finds one that hasn't been chosen already
            do
            {
                int randomIndex = Random.Range(0, possibleCards.Count);
                randomCard = possibleCards[randomIndex];
            } while (cardsChosenAlready.Contains(randomCard));
            cardsChosenAlready.Add(randomCard);
            
            Card card = new(randomCard);
            cardUI.Setup(card);
            Button button = cardUI.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => SetSelectedCard(randomCard));
        }
    }

    public void SetSelectedCard(CardData cardData)
    {
        selectedCard = cardData;
        Debug.Log("Selected card: " + selectedCard.name);
    }

    public void AddCardToDeck()
    {
        GameManager.Instance.heroDataRuntime.deck.Add(selectedCard);
        Debug.Log("Added card to deck: " + selectedCard.name);
    }
}
