using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatantView : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private StatusEffectsUI statusEffectsUI;

    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }
    private Dictionary<StatusEffectType, int> statusEffects = new();
    
    protected void SetupBase(int health, Sprite image)
    {
        maxHealth = currentHealth = health;
        spriteRenderer.sprite = image;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP: " + currentHealth;
    }

    public virtual void Damage(int damageAmount)
    {
        int remainingDamage = damageAmount + GetStatusEffectStacks(StatusEffectType.STICKY);
        int currentBlock = GetStatusEffectStacks(StatusEffectType.BLOCK);
        if (currentBlock > 0)
        {
            if (currentBlock >= damageAmount)
            {
                RemoveStatusEffect(StatusEffectType.BLOCK, remainingDamage);
                remainingDamage = 0;
            }
            else if (currentBlock < damageAmount)
            {
                RemoveStatusEffect(StatusEffectType.BLOCK, currentBlock);
                remainingDamage -= currentBlock;
            }
        }
        if (remainingDamage > 0)
        {
            currentHealth -= remainingDamage;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }
        
        transform.DOShakePosition(0.2f, 0.5f);
        UpdateHealthText();
    }

    public void AddStatusEffect(StatusEffectType type, int stackCount)
    {
        if (statusEffects.ContainsKey(type))
        {
            statusEffects[type] += stackCount;
        }
        else
        {
            statusEffects.Add(type, stackCount);
        }
        statusEffectsUI.UpdateStatusEffectsUI(type, GetStatusEffectStacks(type));
    }

    public void RemoveStatusEffect(StatusEffectType type, int stackCount)
    {
        if (statusEffects.ContainsKey(type))
        {
            statusEffects[type] -= stackCount;
            if (statusEffects[type] <= 0)
            {
                statusEffects.Remove(type);
            }
        }
        statusEffectsUI.UpdateStatusEffectsUI(type, GetStatusEffectStacks(type));
    }

    public int GetStatusEffectStacks(StatusEffectType type)
    {
        if(statusEffects.ContainsKey(type))
            return statusEffects[type];
        else
            return 0;
    }
}
