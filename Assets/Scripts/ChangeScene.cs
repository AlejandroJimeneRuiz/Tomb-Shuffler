
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nombreEscena;
    public float distanciaMaxima = 1.5f;
    public Transform jugador;
    private bool cerca;



        void Start()
        {
            jugador = Camera.main.transform;
        }

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) // Ensure the collider belongs to the player
    {
        SceneManager.LoadScene(nombreEscena);
    }
}

}
