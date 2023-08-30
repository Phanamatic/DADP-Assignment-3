using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    public PlayerController PlayerController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerController.IsPlayerAlive())
        {
            if(isPaused)
            {
                Cursor.lockState = CursorLockMode.Locked; // Lock the cursor back for gameplay
                Cursor.visible = false;
                Resume();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor
                Cursor.visible = true;
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  // Resume game time
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;  // Freeze game time
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");  // Replace with your main menu scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
