using UnityEngine;

public class BearAI : MonoBehaviour
{
    public float speed = 2f;              // Bear movement speed
    public float detectionRadius = 10f;   // How far the bear detects bees
    public float attackRange = 1f;        // Distance at which the bear attacks
    public float attackCooldown = 2f;     // Time between attacks

    private Transform targetBee;
    private float lastAttackTime = 0f;

    void Update()
    {
        FindClosestBee();

        if (targetBee != null)
        {
            float distance = Vector2.Distance(transform.position, targetBee.position);

            if (distance > attackRange)
            {
                MoveTowardsBee();  // Move if not in range
            }
            else
            {
                AttackBee();  // Attack when close enough
            }
        }
    }

    void FindClosestBee()
    {
        GameObject[] bees = GameObject.FindGameObjectsWithTag("Bee");
        float shortestDistance = detectionRadius;
        Transform closestBee = null;

        foreach (GameObject bee in bees)
        {
            float distance = Vector2.Distance(transform.position, bee.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestBee = bee.transform;
            }
        }

        targetBee = closestBee;
    }

    void MoveTowardsBee()
    {
        if (targetBee == null) return;

        Vector2 direction = (targetBee.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void AttackBee()
    {
        if (Time.time - lastAttackTime < attackCooldown) return; // Prevent spam attacks

        Debug.Log("Bear attacks the bee!");
        lastAttackTime = Time.time;

        // Example: Destroy the bee
        Destroy(targetBee.gameObject);

        // After attack, reset target so bear finds a new bee
        targetBee = null;
    }
}