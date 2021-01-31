using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerBody;
    [SerializeField]
    private PlayerRenderer playerRenderer;
    [SerializeField]
    private int playerSpeed;

    private void Update()
    {
        if (GameManager.Instance.inWorld)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.OpenMenu();
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.inWorld)
        {
            Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            playerBody.velocity = playerInput.normalized * playerSpeed;
            playerRenderer.SetDirection(playerInput);
        }
    }
}
