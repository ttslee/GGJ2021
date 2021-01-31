using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    private Vector3[] playerDetectorPos;
    [SerializeField]
    private Vector3[] playerDetectorRot;

    public void SetDetector(int direction)
    {
        Vector3 newPos = playerDetectorPos[direction];
        Vector3 newRot = playerDetectorRot[direction];
        transform.localPosition = newPos;
        transform.localRotation = Quaternion.Euler(newRot.x, newRot.y, newRot.z);
    }
}
