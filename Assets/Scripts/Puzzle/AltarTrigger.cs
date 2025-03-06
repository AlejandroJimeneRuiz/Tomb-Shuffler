using UnityEngine;
using TMPro;
using System.Collections;

public class AltarTrigger : MonoBehaviour
{
    public TextMeshProUGUI textoDialogo;
    public string[] dialogos = {
        "Press F to stop move",
        "Press ← to select nut",
        "Press E to rotate",
        "Press F to move"
    };
    private bool mostrandoDialogo = false;

    void Start()
    {
        // Asegúrate de que el texto esté oculto al inicio
        if (textoDialogo != null)
        {
            textoDialogo.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !mostrandoDialogo)
        {
            StartCoroutine(MostrarDialogo());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ocultar el texto si el jugador sale del trigger
            if (textoDialogo.gameObject.activeSelf)
            {
                textoDialogo.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator MostrarDialogo()
    {
        mostrandoDialogo = true;
        textoDialogo.gameObject.SetActive(true);

        foreach (string linea in dialogos)
        {
            textoDialogo.text = linea;
            yield return new WaitForSeconds(2f);
        }

        textoDialogo.gameObject.SetActive(false);
        mostrandoDialogo = false;
    }
}

