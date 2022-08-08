using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Options Menu
/// </summary>
public class OptionsMenu : MonoBehaviour
{
	[SerializeField] private Toggle _invertYToggle;
	[SerializeField] private Slider _BGMSlider, _SFXSlider;
	private string _BGMVolume = "BGMVolume", _SFXVolume = "SFXVolume";

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

	/// <summary>
	/// Load KeyboardRebinding scene
	/// </summary>
	public void KeyboardRebinding()
	{
		SceneManager.LoadScene("KeyboardRebinding");
	}

	/// <summary>
	/// Load GamepadRebinding scene
	/// </summary>
	public void GamepadRebinding()
	{
		SceneManager.LoadScene("GamepadRebinding");
	}

	// Set Y camera toggle
	private void SetToggleValue()
	{
		if (_invertYToggle.isOn)
		{
			PlayerPrefs.SetInt("invertYToggleState", 1);
		}
		else if (!_invertYToggle.isOn)
		{
			PlayerPrefs.SetInt("invertYToggleState", 0);
		}
	}

	// Get Y camera toggle
	private void GetToggleValue()
	{
		if (PlayerPrefs.GetInt("invertYToggleState") == 1)
		{
			_invertYToggle.isOn = true;
		}
		if (PlayerPrefs.GetInt("invertYToggleState") == 0)
		{
			_invertYToggle.isOn = false;
		}
	}

	// Set sounds slider values
	private void SetSliderValue()
	{
		PlayerPrefs.SetFloat(_BGMVolume, _BGMSlider.value);
		PlayerPrefs.SetFloat(_SFXVolume, _SFXSlider.value);
	}

	// Get sounds slider values
	private void GetSliderValue()
	{
		_BGMSlider.value = PlayerPrefs.GetFloat(_BGMVolume, _BGMSlider.value);
		_SFXSlider.value = PlayerPrefs.GetFloat(_SFXVolume, _SFXSlider.value);
	}
}
