using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardData> cardDatas;
    [SerializeField] private CardView cardView;

    private List<Card> deck;

    // Start is called before the first frame update
    private void Start()
    {
        deck = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
