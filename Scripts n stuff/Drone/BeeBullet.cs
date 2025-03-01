using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    public float bulletSpeed = 5f;  // Speed at which the bullet moves
    private Vector2 direction;      // Direction the bullet is moving

    void Start()
    {
        // Destroy the bullet after 5 seconds if it doesn't hit anything
        Destroy(gameObject, 5f);
    }

    public void SetDirection(Vector2 moveDirection)
    {
        direction = moveDirection;
    }

    void Update()
    {
        // Move the bullet in the specified direction
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with the bear
        if (other.CompareTag("Bear"))
        {
            Debug.Log("Bullet hit the bear!");

            // Find the Bear component
            Bear bear = other.GetComponent<Bear>();

            // Check if Bear script is found and apply damage
            if (bear != null)
            {
                bear.TakeDamage(1);
                Debug.Log("Bullet hit the bear! Bear's health: " + bear.health);
            }
            else
            {
                Debug.Log("No Bear component found!");
            }

            // Destroy the bullet after collision
            Destroy(gameObject);
        }
    }

}
