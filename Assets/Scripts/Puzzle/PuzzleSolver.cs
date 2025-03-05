using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolver : MonoBehaviour
{
    public RotateNut[] nuts; // Array de tuercas
    public int[] requiredRotations; // Número de giros necesarios para cada tuerca
    public DoorOpener doorOpener; // Referencia al script de la puerta

    void Start()
    {
        for (int i = 0; i < nuts.Length; i++)
        {
            nuts[i].SetRequiredRotation(requiredRotations[i]);
        }
    }

    void Update()
    {
        if (IsPuzzleSolved())
        {
            doorOpener.OpenDoors();
            this.enabled = false; // Desactiva este script para evitar múltiples aperturas
        }
    }

    bool IsPuzzleSolved()
    {
        for (int i = 0; i < nuts.Length; i++)
        {
            if (nuts[i].GetCurrentRotation() != requiredRotations[i])
            {
                return false;
            }
        }
        return true;
    }
}
