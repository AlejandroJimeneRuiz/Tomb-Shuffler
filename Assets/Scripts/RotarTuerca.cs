using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarTuerca : MonoBehaviour
{
    public PuzzleNutScript tuerca; // Referencia al script PuzzleNutScript
    private bool isRotating = false;
    private float velocidadRotacion = 5f;

    void Update()
    {
        // Comenzar a rotar si el bot�n del rat�n est� presionado sobre el objeto
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit) && hit.transform == transform)
            {
                isRotating = true;
            }
        }

        // Detener la rotaci�n cuando se suelta el bot�n del rat�n
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        // Rotar el objeto si estamos en modo rotaci�n
        if (isRotating)
        {
            float movimientoY = Input.GetAxis("Mouse Y") * velocidadRotacion;
            transform.Rotate(Vector3.right, -movimientoY);
        }
    }
}
