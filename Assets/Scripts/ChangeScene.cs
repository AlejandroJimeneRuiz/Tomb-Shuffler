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

    private void Update()
    {
        if (Vector3.Distance(jugador.transform.position, transform.position) < distanciaMaxima)
        {
            cerca = true;
        }
        else
        {
            cerca = false;
        }

        if (cerca == true && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
