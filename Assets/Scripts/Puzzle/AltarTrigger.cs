using UnityEngine;
using TMPro;

public class AltarTrigger : MonoBehaviour
{
    public TextMeshProUGUI textoDialogo;
    public string[] dialogos = {
        "Press F to stop move",
        "Press ← to select nut",
        "Press E to rotate",
        "Press F to move"
    };

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
        if (other.CompareTag("Player"))
        {
            // Mostrar el texto completo cuando el jugador entra en el trigger
            string dialogoCompleto = string.Join("\n", dialogos);
            textoDialogo.text = dialogoCompleto;
            textoDialogo.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ocultar el texto cuando el jugador sale del trigger
            textoDialogo.gameObject.SetActive(false);
        }
    }
}
