using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Camera mainCamera; // Add a reference to the camera
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    public Button resumeButton;
    public Button mainMenuButton;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(MainMenu);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {   
                Cursor.lockState = CursorLockMode.Locked;
                ResumeGame();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                PauseGame();
            }
        }
    }

    public void PauseGame() 
    {
        // Lock the camera here
        mainCamera.enabled = false; // Disable camera control or lock it
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame() 
    {
        // Unlock the camera here
        mainCamera.enabled = true; // Enable camera control or unlock it
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Inicio");
    }

}
