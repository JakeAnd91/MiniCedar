using UnityEngine;

public class Bear : MonoBehaviour
{
    public int health = 5;  // Initial health for the bear

    // This method gets called when the bear is hit by a bullet
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Print the bear's current health to the console
        Debug.Log("Bear's current health: " + health);

        // If health reaches 0, the bear dies
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // You can add logic here for the bear's death (e.g., play death animation, destroy the bear)
        Debug.Log("Bear has died!");
        Destroy(gameObject);  // Destroy the bear
    }
}
