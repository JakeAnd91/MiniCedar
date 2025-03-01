using UnityEngine;

public class BeeShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f; // Adjust fire rate if needed

    private float nextFireTime = 0f;
    private Vector2 lastMoveDirection = Vector2.right; // Default shooting direction

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public void UpdateMoveDirection(Vector2 moveDirection)
    {
        // Only update if moveDirection is valid
        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection.normalized;
        }
        else
        {
            Debug.LogWarning("Move direction is invalid (Vector2.zero).");
        }
    }

    void Shoot()
    {
        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogError("FirePoint or BulletPrefab is not assigned.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        BeeBullet bulletScript = bullet.GetComponent<BeeBullet>();

        if (bulletScript != null)
        {
            bulletScript.SetDirection(lastMoveDirection);
        }
        else
        {
            Debug.LogError("BeeBullet script is missing on BulletPrefab.");
        }
    }
}
