using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text cardClass;
    [SerializeField] private SpriteRenderer cardImage;
    [SerializeField] private GameObject wrapper;

    public Card card { get; private set; }
    public void Setup(Card card)
    {
        this.card = card;
        title.text = card.title;
        cost.text = card.cost.ToString();
        description.text = card.effect;
        cardClass.text = card.cardClass;
        cardImage.sprite = card.sprite;
    }

    private void OnMouseEnter()
    {
        wrapper.SetActive(false);
        Vector3 pos = new(transform.position.x, -2, 0);
        CardViewHoverSystem.Instance.Show(card, pos);
    }

    private void OnMouseExit()
    {
        CardViewHoverSystem.Instance.Hide();
        wrapper.SetActive(true);
    }
}
