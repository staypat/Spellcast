using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardImage;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text cost;

    private Card card;
    public void Setup(Card card)
    {
        this.card = card;
        cardImage.sprite = card.sprite;
        title.text = card.title;
        cost.text = card.cost.ToString();
    }
}
