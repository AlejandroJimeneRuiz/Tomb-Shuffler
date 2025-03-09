using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded; // Detecta cambio de escena
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "JuegoPuzzle") 
        {
            Destroy(gameObject); // Destruye el objeto al salir del menú
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Limpia el evento
    }
}


