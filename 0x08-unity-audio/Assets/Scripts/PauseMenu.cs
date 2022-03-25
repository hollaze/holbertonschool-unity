using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Pause Menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioMixerSnapshot unPaused, paused;
    public static bool gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else if (!gameIsPaused)
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;
        paused.TransitionTo(0f);
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
        unPaused.TransitionTo(0f);
    }

    /// <summary>
    /// Restart actual level
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Leads to MainMenu scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Go to Options scene and get last scene
    /// </summary>
    public void Options()
    {
        PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }
}
