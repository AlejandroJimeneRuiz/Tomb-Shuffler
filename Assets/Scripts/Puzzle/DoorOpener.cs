using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject[] doors; // Array de puertas (puedes agregar m�s puertas aqu�)
    private bool[] isOpen; // Estado de apertura para cada puerta

    // Constante para el �ngulo de rotaci�n en sentido antihorario
    private const float OpenAngleCounterClockwise = -90f;  // Abre en sentido antihorario
    private const float ClosedAngle = 0f;
    public AudioClip Clip;

    void Start()
    {
        // Inicializa el estado de apertura para cada puerta
        isOpen = new bool[doors.Length];
        for (int i = 0; i < doors.Length; i++)
        {
            isOpen[i] = false;
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            GameObject door = doors[i];

            if (!isOpen[i])
            {
                OpenDoor(door, i);

            }
            else
            {
                CloseDoor(door, i);
            }
        }
        AudioSource.PlayClipAtPoint(Clip, this.transform.position);        
    }

    private void OpenDoor(GameObject door, int index)
    {
        // Ambas puertas giran en sentido antihorario
        if (door.name.Contains("D") || door.name.Contains("i"))
        {
            door.transform.rotation = Quaternion.Euler(0, 0, OpenAngleCounterClockwise);
        }
        
        isOpen[index] = true;
        Debug.Log("La puerta " + door.name + " se ha abierto con rotaci�n: " + door.transform.eulerAngles);
    }

    private void CloseDoor(GameObject door, int index)
    {
        door.transform.rotation = Quaternion.Euler(0, 0, ClosedAngle);
        isOpen[index] = false;
        Debug.Log("La puerta " + door.name + " se ha cerrado.");
    }
}
