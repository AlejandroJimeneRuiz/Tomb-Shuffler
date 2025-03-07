using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNut : MonoBehaviour
{
    public RotateNut[] nuts; // Array de las tuercas del puzzle
    private int selectedNutIndex = 0; // Índice de la tuerca seleccionada
    public GameObject player; // Referencia al objeto del jugador
    public MonoBehaviour playerMovementScript; // Variable para seleccionar el script del movimiento del jugador desde el Inspector
    private bool isFKeyPressed = false; // Variable para controlar si se presionó F

    // Material de resaltado (se crea en Start)
    private Material highlightMaterial;

    void Start()
    {
        // Crea una copia del material de resaltado
        highlightMaterial = new Material(nuts[0].GetComponent<Renderer>().material);
        highlightMaterial.color = Color.yellow; // Color de resaltado
    }

    void Update()
    {
        // Detecta la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFKeyPressed = true;
        }

        // Si se presionó F, activa o desactiva el script del movimiento del jugador
        if (isFKeyPressed)
        {
            // Activa o desactiva el script del movimiento del jugador
            playerMovementScript.enabled = !playerMovementScript.enabled;
            isFKeyPressed = false; // Restablece la variable
        }

        // Cambia la tuerca seleccionada con las flechas
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedNutIndex = (selectedNutIndex + 1) % nuts.Length;
            UpdateNutHighlight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedNutIndex = (selectedNutIndex - 1 + nuts.Length) % nuts.Length;
            UpdateNutHighlight();
        }

        // Gira la tuerca seleccionada al presionar E
        if (Input.GetKeyDown(KeyCode.E))
        {
            nuts[selectedNutIndex].Rotate90Degrees();
        }
    }

    void UpdateNutHighlight()
    {
        // Restablece el material original de todas las tuercas
        foreach (RotateNut nut in nuts)
        {
            nut.GetComponent<Renderer>().material = nuts[0].GetComponent<Renderer>().material;
        }

        // Aplica el material de resaltado a la tuerca seleccionada
        nuts[selectedNutIndex].GetComponent<Renderer>().material = highlightMaterial;
    }
}
