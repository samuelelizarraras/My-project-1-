using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health of the player
    private int currentHealth; // Current health of the player
    private bool isImmune = false; // Flag to indicate if the player is immune
    public float immunityDuration = 2f; // Duration of immunity after being hit
    public Color immuneColor = Color.red; // Color to blink when immune
    private Color originalColor; // Original color of the player
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with an enemy
        if (other.CompareTag("Enemy") && !isImmune)
        {
            // Reduce player's health
            TakeDamage(1); // Adjust the damage amount as needed
            // Start immunity period
            StartImmunity();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform death-related actions (e.g., play death animation, game over screen, etc.)
        Debug.Log("Player died!");
        // For demonstration purposes, we'll just deactivate the player GameObject
        gameObject.SetActive(false);
    }

    void StartImmunity()
    {
        isImmune = true;
        spriteRenderer.color = immuneColor;
        Invoke("EndImmunity", immunityDuration);
    }

    void EndImmunity()
    {
        isImmune = false;
        spriteRenderer.color = originalColor;
    }
}
