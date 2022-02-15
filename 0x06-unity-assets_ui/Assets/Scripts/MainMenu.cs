using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle the MainMenu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// Select the level you want to go
    /// </summary>
    /// <param name="level">level wanted</param>
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("actual_level", level);
    }

    /// <summary>
    /// Go to Options scene and get last scene
    /// </summary>
    public void Options()
    {
        SceneManager.LoadScene("Options");
        PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Exit game
    /// </summary>
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }

}
