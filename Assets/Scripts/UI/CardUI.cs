using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text cardClass;
    [SerializeField] private Image cardImage;

    public Card card { get; private set; }

    public void Setup(Card card)
    {
        this.card = card;
        title.text = card.title;
        cost.text = card.cost.ToString();
        description.text = card.description;
        cardClass.text = card.cardClass;
        cardImage.sprite = card.sprite;
    }
}
