using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNutScript : MonoBehaviour
{
    public int nutID;
    public Vector3 correctPosition;
    public Quaternion correctRotation;
    public float positionTolerance = 0.1f;
    public float rotationTolerance = 5f;

    public bool IsCorrectlyPositioned()
    {
        float distance = Vector3.Distance(transform.position, correctPosition);
        float angleDifference = Quaternion.Angle(transform.rotation, correctRotation);
        return distance < positionTolerance && angleDifference < rotationTolerance;
    }
}
