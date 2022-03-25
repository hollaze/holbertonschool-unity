using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionSliders : MonoBehaviour
{
    public Slider m_BGMSlider, m_SFXSlider;
    public AudioMixer m_MasterMixer;
    private string m_BGMVolume = "BGMVolume", m_SFXVolume = "SFXVolume";
    public float multiplier = 28f;

    private void Awake()
    {
        m_BGMSlider.onValueChanged.AddListener(HandleBGMSliderValueChanged);
        m_SFXSlider.onValueChanged.AddListener(HandleSFXSliderValueChanged);
    }

    private void HandleBGMSliderValueChanged(float value)
    {
        m_MasterMixer.SetFloat(m_BGMVolume, Mathf.Log10(value) * multiplier);
    }

    private void HandleSFXSliderValueChanged(float value)
    {
        m_MasterMixer.SetFloat(m_SFXVolume, Mathf.Log10(value) * multiplier);
    }
}
