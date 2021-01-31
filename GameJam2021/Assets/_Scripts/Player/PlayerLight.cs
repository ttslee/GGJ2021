using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField]
    private Vector3[] lightPositions; // Local

    public void SetLight(int direction)
    {
        Vector3 newPos = lightPositions[direction];
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, .3f);
    }
}
