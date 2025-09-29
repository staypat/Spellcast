using DG.Tweening;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : Singleton<CardSystem>
{
    [SerializeField] private HandView handView;
    [SerializeField] private Transform drawPilePoint;
    [SerializeField] private Transform discardPilePoint;

    private readonly List<Card> drawPile = new();
    private readonly List<Card> discardPile = new();
    private readonly List<Card> hand = new();

    public PlateBoardView plateBoardView;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DrawCardsGA>(DrawCardsPerformer);
        ActionSystem.AttachPerformer<DiscardAllCardsGA>(DiscardAllCardsPerformer);
        ActionSystem.AttachPerformer<PlayCardGA>(PlayCardPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DrawCardsGA>();
        ActionSystem.DetachPerformer<DiscardAllCardsGA>();
        ActionSystem.DetachPerformer<PlayCardGA>();
    }

    public void Setup(List<CardData> deckData)
    {
        foreach(var cardData in deckData)
        {
            Card card = new(cardData);
            drawPile.Add(card);
        }
    }

    private IEnumerator DrawCardsPerformer(DrawCardsGA drawCardsGA)
    {
        int actualAmount = Mathf.Min(drawCardsGA.amount, drawPile.Count);
        int notDrawnAmount = drawCardsGA.amount - actualAmount;

        for(int i = 0; i < actualAmount; i++)
        {
            yield return DrawCard();
        }
        if (notDrawnAmount > 0)
        {
            RefillDeck();
            for(int i = 0; i < notDrawnAmount; i++)
            {
                yield return DrawCard();
            }
        }
    }

    private IEnumerator DiscardAllCardsPerformer(DiscardAllCardsGA discardAllCardsGA)
    {
        foreach(var card in hand)
        {
            CardView cardView = handView.RemoveCard(card);
            yield return DiscardCard(cardView);
        }
        hand.Clear();
    }

    private IEnumerator PlayCardPerformer(PlayCardGA playCardGA)
    {
        hand.Remove(playCardGA.card);
        CardView cardView = handView.RemoveCard(playCardGA.card);
        yield return DiscardCard(cardView);

        SpendManaGA spendManaGA = new(playCardGA.card.cost);
        ActionSystem.Instance.AddReaction(spendManaGA);

        if (playCardGA.card.delayedEffects != null)
        {
            foreach (var effect in playCardGA.card.delayedEffects)
            {
                if (effect is ConditionalEffect conditionalEffect)
                {
                    GameAction actualEffect = conditionalEffect.GetGameAction(new List<CombatantView> { playCardGA.plate.target }, HeroSystem.Instance.heroView, playCardGA.plate);
                    playCardGA.plate.AddAction(actualEffect, playCardGA.card.cardClass);
                }
                else
                {
                    PerformEffectGA performEffectGA = new(effect, new() { playCardGA.plate.target }, playCardGA.plate);
                    playCardGA.plate.AddAction(performEffectGA, playCardGA.card.cardClass);
                }
            }
            plateBoardView.SpawnIngredientAbovePlate(playCardGA.card.cardClass, playCardGA.plate);
            playCardGA.plate.lastPlayedCardClass = playCardGA.card.cardClass;
        }
        foreach (var effectWrapper in playCardGA.card.instantEffects)
        {
            List<CombatantView> targets = effectWrapper.targetMode.GetTargets();
            PerformEffectGA performEffectGA = new(effectWrapper.effect, targets, playCardGA.plate);
            ActionSystem.Instance.AddReaction(performEffectGA);
        }
    }

    // Helpers
    private IEnumerator DrawCard()
    {
        Card card = drawPile.Draw();
        hand.Add(card);
        CardView cardView = CardViewCreator.Instance.CreateCardView(card, drawPilePoint.position, drawPilePoint.rotation);
        yield return handView.AddCard(cardView);
    }

    private void RefillDeck()
    {
        drawPile.AddRange(discardPile);
        discardPile.Clear();
    }

    private IEnumerator DiscardCard(CardView cardView)
    {
        discardPile.Add(cardView.card);
        cardView.transform.DOScale(Vector3.zero, 0.15f);
        Tween tween = cardView.transform.DOMove(discardPilePoint.position, 0.15f);
        yield return tween.WaitForCompletion();
        Destroy(cardView);
    }
}
