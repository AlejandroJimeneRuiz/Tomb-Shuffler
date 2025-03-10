using UnityEngine;
using System.Collections;

public class SonidoCofre : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtiene el componente AudioSource
    }

    // Método que inicia el Coroutine para reproducir el sonido con retraso
    public void PlaySoundWithDelay(float delay)
    {
        StartCoroutine(PlaySoundCoroutine(delay));  // Inicia el Coroutine
    }

    // Coroutine que maneja el retraso antes de reproducir el sonido
    private IEnumerator PlaySoundCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);  // Espera el tiempo de retraso
        audioSource.Play();  // Reproduce el sonido
    }
}



