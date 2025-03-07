using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Animation chestAnimation;
    private bool playerNearby = false;
    private bool hasOpened = false; // Nueva variable para evitar repetir la animación

    // Start is called before the first frame update
    void Start()
    {
        if (chestAnimation == null)
        {
            chestAnimation = GetComponent<Animation>();
        }
    }

    // Detecta cuando el jugador entra en el área de activación
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Detecta cuando el jugador sale del área de activación
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    // Verifica si el jugador presiona "E" mientras está cerca
    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E) && !hasOpened)
        {
            chestAnimation.Play();
            hasOpened = true; // Evita que se reproduzca nuevamente
        }
    }
}
