using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        // Get the Rigidbody2D component attached to the player GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calculate movement direction
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Normalize movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the player
        rb.velocity = movement * moveSpeed;

        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction to mouse cursor
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player towards the mouse cursor
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f)); // Adjusting the angle by -90 degrees to match sprite orientation
    }
}
