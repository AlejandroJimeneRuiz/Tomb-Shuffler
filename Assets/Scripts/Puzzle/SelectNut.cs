using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectNut : MonoBehaviour
{
    public RotateNut[] nuts; // Array de las tuercas del puzzle
    private int selectedNutIndex = 0; // Índice de la tuerca seleccionada
    public TextMeshPro nutText; // Referencia al objeto de texto 3D
    public GameObject player; // Referencia al objeto del jugador
    public MonoBehaviour playerMovementScript; // Variable para seleccionar el script del movimiento del jugador desde el Inspector
    private bool isFKeyPressed = false; // Variable para controlar si se presionó F

    // Material de resaltado (se crea en Start)
    private Material highlightMaterial;

    void Start()
    {
        // Verifica que el objeto de texto esté asignado
        if (nutText == null)
        {
            Debug.LogError("El objeto de texto no está asignado en el inspector.");
            return;
        }

        // Desactiva el texto al inicio
        nutText.gameObject.SetActive(false);

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

            // Si el script del movimiento del jugador está desactivado, activa el texto
            if (!playerMovementScript.enabled)
            {
                nutText.gameObject.SetActive(true);
                nutText.text = "↓"; // Carácter de flecha hacia abajo
                UpdateNutTextPosition();
            }
            else
            {
                // Si el script del movimiento del jugador está activado, desactiva el texto
                nutText.gameObject.SetActive(false);
            }

            isFKeyPressed = false; // Restablece la variable
        }

        // Cambia la tuerca seleccionada con las flechas
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedNutIndex = (selectedNutIndex + 1) % nuts.Length;
            UpdateNutTextPosition();
            UpdateNutHighlight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedNutIndex = (selectedNutIndex - 1 + nuts.Length) % nuts.Length;
            UpdateNutTextPosition();
            UpdateNutHighlight();
        }

        // Gira la tuerca seleccionada al presionar E
        if (Input.GetKeyDown(KeyCode.E))
        {
            nuts[selectedNutIndex].Rotate90Degrees();
        }
    }

    void UpdateNutTextPosition()
    {
        // Verifica que haya tuercas en el array
        if (nuts.Length == 0)
        {
            Debug.LogError("No hay tuercas asignadas en el array.");
            return;
        }

        // Posiciona el texto sobre la tuerca seleccionada
        Vector3 nutPosition = nuts[selectedNutIndex].transform.position;
        nutText.transform.position = nutPosition;

        // Ajusta la rotación del texto para que mire a la cámara
        nutText.transform.rotation = Camera.main.transform.rotation;
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
