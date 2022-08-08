using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// This script doesn't work yet
// Gamepad UI navigation, first selected button
public class FirstGamepadSelectedButton : MonoBehaviour
{
	[SerializeField] private GameObject _winCanvas, _pauseCanvas;
	[SerializeField] private Button _winMenuButton, _pauseRestartButton;
	private EventSystem _eventSystem;

	private void Awake()
	{
		_eventSystem = GetComponent<EventSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		SelectedCanvas();
	}

	private void SelectedCanvas()
	{
		if (_winCanvas.activeInHierarchy)
		{
			_eventSystem.firstSelectedGameObject = _winMenuButton.gameObject;
			_winMenuButton.Select();
		}
		else if (_pauseCanvas.activeInHierarchy)
		{
			_eventSystem.firstSelectedGameObject = _pauseRestartButton.gameObject;
			_pauseRestartButton.Select();
		}
	}
}
