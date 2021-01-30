using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField]
    private Light2D playerLight;

    [SerializeField]
    private Vector3[] lightPositions; // Local

    public void SetLight(int direction)
    {
        Vector3 newPos = lightPositions[direction];
        playerLight.transform.localPosition = Vector3.Lerp(playerLight.transform.localPosition, newPos, .3f);
    }
}
