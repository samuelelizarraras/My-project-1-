using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth;
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
        // Perform death-related actions (e.g., play death animation, drop loot, etc.)
        Destroy(gameObject);
    }
}
