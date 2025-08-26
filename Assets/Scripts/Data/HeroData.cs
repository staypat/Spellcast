using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Hero")]
public class HeroData : ScriptableObject
{
    [field: SerializeField] public Sprite image {  get; private set; }
    [field: SerializeField] public int health { get; private set; }
    [field: SerializeField] public List<CardData> deck {  get; private set; }
}
