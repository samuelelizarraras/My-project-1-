using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // Damage inflicted by the bullet

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet hit an enemy
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.TakeDamage(damage);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
