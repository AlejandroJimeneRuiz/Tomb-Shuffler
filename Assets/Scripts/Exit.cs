using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exitButton; 

    void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(QuitGame);
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
            Application.Quit(); // Para cerrar el juego compilado
#endif
    }
}
