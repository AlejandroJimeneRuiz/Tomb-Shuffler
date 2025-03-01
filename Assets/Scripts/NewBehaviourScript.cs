using UnityEngine;

public class PickUpCube : MonoBehaviour
{
    public GameObject panelUI; // Asigna el Panel desde el Inspector
    private bool isNearCube = false;

    void Update()
    {
        if (isNearCube && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tecla E presionada - Panel activado");
            panelUI.SetActive(true);
        }

        if (panelUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Tecla Escape presionada - Panel ocultado");
            panelUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador cerca del cubo");
            isNearCube = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador se alejó del cubo");
            isNearCube = false;
        }
    }
}

