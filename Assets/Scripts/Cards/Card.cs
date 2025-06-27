using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    [Header("Card Info")]
    public string name;
    public int manaCost;
    public string rarity;
    public Sprite art;

    public abstract void PlayCard(Player player = null, Character target = null);
}
