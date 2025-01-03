using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    private int currentHealth; // Current health

    public Slider healthBar;   // Reference to the health bar slider
    public GameUIManager gameUIManager; // reference to ui manager for showing death screen

    void Start()
    {
        currentHealth = maxHealth; // Start with full health
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth; // Update slider value
        }
    }

    private void Die()
    {
        gameUIManager.ShowDeathScreen();
    }
}