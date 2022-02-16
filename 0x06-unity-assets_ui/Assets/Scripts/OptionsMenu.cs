using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

/// <summary>
/// Options Menu
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;

    void Awake()
    {
        if (PlayerPrefs.GetInt("invertYToggleState") == 1)
        {
            invertYToggle.isOn = true;
        }
        if (PlayerPrefs.GetInt("invertYToggleState") == 0)
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
        toggleOnOff();
    }

    /// <summary>
    /// Get toggle on or off
    /// </summary>
    public void toggleOnOff()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("invertYToggleState", 1);
        }
        else if (!invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("invertYToggleState", 0);
        }
    }
}
