using TMPro;
using UnityEngine;

public class CombatantView : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }
    
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
}
