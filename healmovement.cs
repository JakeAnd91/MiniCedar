using UnityEngine;

public class BeeMovement_Player2 : MonoBehaviour
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
        // Move with Arrow Keys
        moveDirection = new Vector2(
            Input.GetKey(KeyCode.RightArrow) ? 1 : Input.GetKey(KeyCode.LeftArrow) ? -1 : 0,
            Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0
        );

        if (moveDirection != Vector2.zero)
        {
            transform.position += (Vector3)moveDirection.normalized * moveSpeed * Time.deltaTime;
            beeShooting.UpdateMoveDirection(moveDirection);
        }

       
    }
}
