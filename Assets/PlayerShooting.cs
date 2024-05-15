using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 10f; // Speed of the bullet
    public float fireRate = 0.5f; // Rate of fire (in seconds)
    public int bulletDamage = 1; // Damage inflicted by each bullet

    private float nextFireTime; // Time of the next allowed shot

    void Update()
    {
        // Check if it's time to shoot
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            // Update the next allowed shot time
            nextFireTime = Time.time + fireRate;

            // Create a new bullet instance
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Get the Rigidbody2D component of the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Apply velocity to the bullet
            rb.velocity = transform.up * bulletSpeed;
        }
    }
}
