using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DercaderDialog : MonoBehaviour
{
    private bool cercaDelMercader = false;
    private bool dialogoActivo = false;
    private int indiceDialogo = 0;
    public string[] dialogo;
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;

    void Start()
    {
        panelDialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cercaDelMercader && Input.GetKeyDown(KeyCode.E))
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
            cercaDelMercader = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDelMercader = false;
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
