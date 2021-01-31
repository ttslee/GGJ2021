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

    private int lastDirection = 5;
    private int sliceCount = 8;
    private float step;
    private float halfStep;

    private void Awake()
    {
        step = 360f / sliceCount;
        halfStep = step / 2;
    }

    public void SetDirection(Vector2 direction)
    {
        float moveSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
        if (direction != Vector2.zero)
        {
            animDelay = Vector3.Lerp(animDelay, direction, 0.9f);
            playerAnim.SetFloat("Horizontal", animDelay.x);
            playerAnim.SetFloat("Vertical", animDelay.y);
            lastDirection = DirectionToIndex(animDelay, 8);
        }
        playerAnim.SetFloat("Speed", moveSpeed);
        playerLight.SetLight(lastDirection);
    }

    public int DirectionToIndex(Vector2 direction, int slice)
    {
        Vector2 normDir = direction.normalized;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += halfStep;
        if (angle < 0) angle += 360;
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
