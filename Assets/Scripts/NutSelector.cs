using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSelector : MonoBehaviour
{
    public float interactionRange = 5f; // Rango de interacción
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectAndRotateNut();
        }
    }

    void SelectAndRotateNut()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            RotateNut nut = hit.collider.GetComponent<RotateNut>();
            if (nut != null)
            {
                nut.Rotate90Degrees();
            }
        }
    }
}
