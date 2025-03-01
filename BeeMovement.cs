using UnityEngine;

public class BeeMovement_Player1 : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 moveDirection;
    private BeeShooting beeShooting;

    void Start()
    {
        beeShooting = GetComponent<BeeShooting>();
    }

    void Update()
    {
        // Move with WASD
        moveDirection = new Vector2(
            Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0,
            Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0
        );

        if (moveDirection != Vector2.zero)
        {
            transform.position += (Vector3)moveDirection.normalized * moveSpeed * Time.deltaTime;
            beeShooting.UpdateMoveDirection(moveDirection);
        }
    }
}
