using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Win Menu
/// </summary>
public class WinMenu : MonoBehaviour
{
    /// <summary>
    /// Leads to MainMenu scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Go to next level, if no other level, goes to menu
    /// </summary>
    public void Next()
    {
        Time.timeScale = 1f;
        PauseMenu.gameIsPaused = false;

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            MainMenu();
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
