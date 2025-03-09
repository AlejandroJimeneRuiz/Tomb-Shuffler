using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolver : MonoBehaviour
{
    public Animation doorAnimation; // Asigna la animación de la puerta en el Inspector
    public AudioSource doorSound; // 🔊 Asigna el sonido de la puerta

    private bool hasOpened = false;

    void Start()
    {
        // Asegurémonos de que las referencias estén asignadas correctamente
        if (doorSound == null)
        {
            Debug.LogError("No se ha asignado el AudioSource de la puerta.");
        }

        if (doorAnimation == null)
        {
            Debug.LogError("No se ha asignado la animación de la puerta.");
        }
    }

    public void OpenDoors()
    {
        // Verifica que no se haya abierto ya
        if (!hasOpened)
        {
            // Reproducir la animación de la puerta
            doorAnimation.Play(); // 🎥 Reproducir animación de la puerta
            Debug.Log("Animación de puerta iniciada.");

            // Reproducir el sonido de la puerta si está asignado
            if (doorSound != null)
            {
                doorSound.Play(); // 🔊 Reproducir sonido de la puerta
                Debug.Log("Sonido de puerta reproducido.");
            }
            else
            {
                Debug.LogWarning("No se ha asignado el sonido de la puerta.");
            }

            // Marcar que la puerta ya se abrió
            hasOpened = true;
        }
    }
}


