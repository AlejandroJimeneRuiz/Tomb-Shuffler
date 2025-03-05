using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject door; // Referencia a la puerta
    private bool isOpen = false;

    public void OpenDoor()
    {
        if (!isOpen)
        {
            door.transform.Rotate(0, 90, 0); // Rota la puerta 90 grados
            isOpen = true;
            Debug.Log("La puerta se ha abierto.");
        }
    }
}
