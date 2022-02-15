using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("last_scene"));
    }

    public void Apply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("invertYToggleState", 1);
            CameraController.isInverted = true;
        }
        else if (!invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("invertYToggleState", 0);
            CameraController.isInverted = false;
        }
    }
}
