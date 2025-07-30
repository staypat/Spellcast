using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Data")]

public class CardData : ScriptableObject
{
    [SerializeField] public Sprite sprite { get; private set; }
    [SerializeField] public int cost { get; private set; }
    [SerializeField] public string cardClass { get; private set; }
    [SerializeField] public string effect { get; private set; }
}
