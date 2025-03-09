using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPCDialog : MonoBehaviour
{
    // Variables
    private bool cercaDelNPC = false;
    private bool dialogoActivo = false;
    private int indiceDialogo = 0;
    public string[] dialogo; // Array para las líneas de diálogo
    public GameObject panelDialogo; // Panel donde se muestra el diálogo en la interfaz
    public TextMeshProUGUI textoDialogo; // Texto que mostrará las líneas del diálogo

    void Start()
    {
        // Asegúrate de que el panel de diálogo está oculto al inicio
        panelDialogo.SetActive(false);
    }

    void Update()
    {
        // Verificar si el jugador está cerca del NPC y presiona la tecla "E"
        if (cercaDelNPC && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogoActivo)
            {
                IniciarDialogo();
            }
            else
            {
                AvanzarDialogo();
            }
        }
    }

    // Detecta cuando el jugador entra en el área del NPC
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Asegúrate de que el tag del jugador sea "Player"
        {
            cercaDelNPC = true;
        }
    }

    // Detecta cuando el jugador sale del área del NPC
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDelNPC = false;
            if (dialogoActivo)
            {
                CerrarDialogo();
            }
        }
    }

    // Inicia el diálogo
    private void IniciarDialogo()
    {
        dialogoActivo = true;
        indiceDialogo = 0;
        panelDialogo.SetActive(true);  // Mostrar el panel de diálogo
        MostrarDialogo();  // Mostrar el primer mensaje
    }

    // Avanza al siguiente mensaje del diálogo
    private void AvanzarDialogo()
    {
        if (indiceDialogo < dialogo.Length - 1)
        {
            indiceDialogo++;
            MostrarDialogo();
        }
        else
        {
            CerrarDialogo();
        }
    }

    // Muestra el texto del diálogo
    private void MostrarDialogo()
    {
        textoDialogo.text = dialogo[indiceDialogo];
    }

    // Cierra el diálogo
    private void CerrarDialogo()
    {
        dialogoActivo = false;
        panelDialogo.SetActive(false);  // Ocultar el panel de diálogo
    }
}
