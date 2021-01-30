using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public static readonly string[] idleDirections = { "Idle N", "Idle NE", "Idle E", "Idle SE", "Idle S", "Idle SW", "Idle W", "Idle NW" };
    public static readonly string[] runDirections = { "Run N", "Run NE", "Run E", "Run SE", "Run S", "Run SW", "Run W", "Run NW" };

    [SerializeField]
    private Animator playerAnim;
    private int lastDirection;

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
        // Holds a reference to an Array (idle or run)
        string[] directionArray = null;
        // If player is standing still
        if (direction.magnitude < .01f)
        {
            directionArray = idleDirections;
        }
        else // If player is moving
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 8);
        }
        playerAnim.Play(directionArray[lastDirection]);
    }

    // Converts a Vector2 direction to an index of circle that is sliced # times
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
