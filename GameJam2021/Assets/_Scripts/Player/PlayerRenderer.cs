using System.Collections;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    private static readonly string[] idleDirections = { "IdleUp", "IdleUpLeft", "IdleLeft", "IdleDownLeft", "IdleDown", "IdleDownRight", "IdleRight", "IdleUpRight" };
    private static readonly string[] walkDirections = { "WalkUp", "WalkUpLeft", "WalkLeft", "WalkDownLeft", "WalkDown", "WalkDownRight", "WalkRight", "WalkUpRight" };

    [SerializeField]
    private Animator playerAnim;
    private Vector3 animDelay;
    [SerializeField]
    private PlayerLight playerLight;

    public void SetDirection(Vector2 direction)
    {
        float moveSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
        if (direction != Vector2.zero) 
        {
            animDelay = Vector3.Lerp(animDelay, direction, 0.9f);
            playerAnim.SetFloat("Horizontal", animDelay.x);
            playerAnim.SetFloat("Vertical", animDelay.y);
        }
        playerAnim.SetFloat("Speed", moveSpeed);
    }
}
