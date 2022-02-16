using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Options Menu
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;

    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("invertYToggleState") == 1)
        {
            invertYToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("invertYToggleState") == 0)
        {
            invertYToggle.isOn = false;
        }
    }

    /// <summary>
    /// Goes back to last scene
    /// </summary>
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("last_scene"));
    }

    /// <summary>
    /// Apply the changes
    /// </summary>
    public void Apply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("invertYToggleState", 1);
            GetComponent<CameraController>().isInverted = true;
        }
        else if (!invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("invertYToggleState", 0);
            GetComponent<CameraController>().isInverted = false;
        }
    }
}
