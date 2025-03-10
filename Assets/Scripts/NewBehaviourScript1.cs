using UnityEngine;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    private bool cercaDelNPC = false;
    private bool dialogoActivo = false;
    private int indiceDialogo = 0;
    public string[] dialogo; 
    public GameObject panelDialogo; 
    public TextMeshProUGUI textoDialogo; // Usamos TextMeshProUGUI en lugar de Text

    void Start()
    {
        panelDialogo.SetActive(false);
    }

    void Update()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDelNPC = true;
        }
    }

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

    private void IniciarDialogo()
    {
        dialogoActivo = true;
        indiceDialogo = 0;
        panelDialogo.SetActive(true);
        MostrarDialogo();
    }

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

    private void MostrarDialogo()
    {
        textoDialogo.text = dialogo[indiceDialogo];
    }

    private void CerrarDialogo()
    {
        dialogoActivo = false;
        panelDialogo.SetActive(false);
    }
}

