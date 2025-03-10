using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNut : MonoBehaviour
{
    private int currentRotation = 0;
    private int requiredRotation = 0; // Rotación requerida para resolver el puzzle
    private bool isRotating = false; // Variable para controlar si está rotando

    public void Rotate90Degrees()
    {
        if (currentRotation != requiredRotation && !isRotating)
        {
            StartCoroutine(RotateSmoothly());
        }
    }

    private IEnumerator RotateSmoothly()
    {
        isRotating = true;
        float elapsedTime = 0f;
        float rotationDuration = 0.5f; // Duración de la rotación en segundos
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(0, 90, 0);

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        currentRotation = (currentRotation + 1) % 4; // Incrementa y mantiene el valor entre 0 y 3
        isRotating = false;
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

