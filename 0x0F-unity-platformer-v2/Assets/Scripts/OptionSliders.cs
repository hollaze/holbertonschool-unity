using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionSliders : MonoBehaviour
{
    [SerializeField] private Slider _BGMSlider, _SFXSlider;
    [SerializeField] private AudioMixer _masterMixer;
    private string _BGMVolume = "BGMVolume", _SFXVolume = "SFXVolume";
    [SerializeField] private float _multiplier = 28f;

    private void Awake()
    {
        _BGMSlider.onValueChanged.AddListener(HandleBGMSliderValueChanged);
        _SFXSlider.onValueChanged.AddListener(HandleSFXSliderValueChanged);
    }

    // Handle BGM slider value
    private void HandleBGMSliderValueChanged(float value)
    {
        _masterMixer.SetFloat(_BGMVolume, Mathf.Log10(value) * _multiplier);
    }

    // Handle SFX slider value
    private void HandleSFXSliderValueChanged(float value)
    {
        _masterMixer.SetFloat(_SFXVolume, Mathf.Log10(value) * _multiplier);
    }
}
