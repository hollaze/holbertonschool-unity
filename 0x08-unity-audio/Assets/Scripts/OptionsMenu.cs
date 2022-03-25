using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Options Menu
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    public Slider m_BGMSlider, m_SFXSlider;
    private string m_BGMVolume = "BGMVolume", m_SFXVolume = "SFXVolume";

    private void Awake()
    {
        GetToggleValue();
        GetSliderValue();
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
        SetToggleValue();
        SetSliderValue();
    }

    
    private void SetToggleValue()
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

    private void GetToggleValue()
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

    private void SetSliderValue()
    {
        PlayerPrefs.SetFloat(m_BGMVolume, m_BGMSlider.value);
        PlayerPrefs.SetFloat(m_SFXVolume, m_SFXSlider.value);
    }

    private void GetSliderValue()
    {
        m_BGMSlider.value = PlayerPrefs.GetFloat(m_BGMVolume, m_BGMSlider.value);
        m_SFXSlider.value = PlayerPrefs.GetFloat(m_SFXVolume, m_SFXSlider.value);
    }
}
