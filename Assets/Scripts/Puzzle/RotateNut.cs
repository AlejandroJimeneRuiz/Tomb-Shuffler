using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNut : MonoBehaviour
{
    private int currentRotation = 0;
    private int requiredRotation = 0; // Rotación requerida para resolver el puzzle

    public void Rotate90Degrees()
    {
        if (currentRotation != requiredRotation)
        {
            transform.Rotate(0, 90, 0);
            currentRotation = (currentRotation + 1) % 4; // Incrementa y mantiene el valor entre 0 y 3
        }
    }

    public int GetCurrentRotation()
    {
        return currentRotation;
    }

    public void SetRequiredRotation(int rotation)
    {
        requiredRotation = rotation % 4; // Asegura que el valor esté entre 0 y 3
    }

    public int GetRequiredRotation()
    {
        return requiredRotation;
    }
}
