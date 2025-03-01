using UnityEngine;

public class BeeMovement : MonoBehaviour
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
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveDirection != Vector2.zero)
        {
            transform.position += (Vector3)moveDirection.normalized * moveSpeed * Time.deltaTime;
            beeShooting.UpdateMoveDirection(moveDirection); // Update shooting direction
        }
    }
}
