using System.Collections;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnim;
    private Vector3 animDelay;
    [SerializeField]
    private PlayerLight playerLight;
    [SerializeField]
    private PlayerDetector playerDetector;

    private int lastDirection;
    private int currentDirection;

    private WaitForSeconds stepDelay = new WaitForSeconds(0.4f);
    private bool canStep = true;

    public void SetDirection(Vector2 direction)
    {
        float moveSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
        if (direction != Vector2.zero)
        {
            // animDelay = direction;
            animDelay = Vector3.Lerp(animDelay, direction, 0.9f);
            lastDirection = currentDirection;
            currentDirection = DirectionToIndex(direction);
            playerAnim.SetFloat("Horizontal", animDelay.x);
            playerAnim.SetFloat("Vertical", animDelay.y);
            // Sound
            if (canStep && !AudioManager.Instance.effectSource.isPlaying)
            {
                StartCoroutine(WaitForStep());
            }
        }
        else if (direction == Vector2.zero)
        {
            if (lastDirection != currentDirection &&
                lastDirection == 1 || lastDirection == 3 || lastDirection == 5 || lastDirection == 7)
                currentDirection = lastDirection;
        }
        playerAnim.SetFloat("Speed", moveSpeed);

        if (playerLight != null)
            playerLight.SetLight(currentDirection);
        if (playerDetector != null)
            playerDetector.SetDetector(currentDirection);
    }

    public int DirectionToIndex(Vector2 direction)
    {
        if (direction.x == 0 && direction.y == 1)
        {
            return 0; // Up
        }
        if (direction.x < 0 && direction.y > 0)
        {
            return 1; // UpLeft
        }
        if (direction.x == -1 && direction.y == 0)
        {
            return 2; // Left
        }
        if (direction.x < 0 && direction.y < 0)
        {
            return 3; // DownLeft
        }
        if (direction.x == 0 && direction.y == -1)
        {
            return 4; // Down
        }
        if (direction.x > 0 && direction.y < 0)
        {
            return 5; // DownRight
        }
        if (direction.x == 1 && direction.y == 0)
        {
            return 6; // Right
        }
        if (direction.x > 0 && direction.y > 0)
        {
            return 7; // UpRight
        }
        return 1;
    }

    public IEnumerator WaitForStep()
    {
        canStep = false;
        AudioManager.Instance.PlayFootstep();
        yield return stepDelay;
        canStep = true;
    }
}
