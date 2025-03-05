using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject[] doors; // Array de puertas (puedes agregar m�s puertas aqu�)
    private bool isOpen = false; // Indica si las puertas est�n abiertas

    public void OpenDoors()
    {
        // Si las puertas est�n cerradas, las abre
        if (!isOpen)
        {
            foreach (GameObject door in doors)
            {
                // Rota cada puerta 90 grados en la direcci�n correcta
                if (door.name.Contains("Left")) // Verifica si el nombre de la puerta contiene "Left"
                {
                    door.transform.Rotate(0, -90, 0); // Rota hacia la izquierda
                }
                else
                {
                    door.transform.Rotate(0, 90, 0); // Rota hacia la derecha
                }
            }
            isOpen = true;
            Debug.Log("Las puertas se han abierto.");
        }
        // Si las puertas est�n abiertas, las cierra
        else
        {
            foreach (GameObject door in doors)
            {
                door.transform.Rotate(0, 0, 0); // Restablece la rotaci�n
            }
            isOpen = false;
            Debug.Log("Las puertas se han cerrado.");
        }
    }
}
