using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerBody;

    [SerializeField]
    private int playerSpeed;

    private float horizontalInput;
    private float verticalInput;

    private void FixedUpdate()
    {
        Vector2 currentPos = playerBody.position;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 playerInput = new Vector2(horizontalInput, verticalInput);
        playerInput = Vector2.ClampMagnitude(playerInput, 1);
        Vector2 playerMovement = playerInput * playerSpeed;
        Vector2 newPos = currentPos + playerMovement * Time.fixedDeltaTime;
        playerBody.MovePosition(newPos);
    }
}
