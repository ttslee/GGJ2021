using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerBody;
    [SerializeField]
    private PlayerRenderer playerRenderer;
    [SerializeField]
    private int playerSpeed;

    private float horizontalInput;
    private float verticalInput;

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 playerInput = new Vector2(horizontalInput, verticalInput);

        // playerInput = Vector2.ClampMagnitude(playerInput, 1);
        // Vector2 playerMovement = playerInput * playerSpeed;
        // Vector2 newPos = playerBody.position + playerMovement * Time.fixedDeltaTime;
        // playerBody.MovePosition(newPos);

        playerBody.velocity = playerInput * playerSpeed;
        playerRenderer.SetDirection(playerInput);
    }
}
