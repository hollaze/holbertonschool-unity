using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    /// <summary>
    /// Load maze scene.
    /// </summary>
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
    }

    /// <summary>
    /// Quit application.
    /// </summary>
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
