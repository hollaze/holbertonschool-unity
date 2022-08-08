using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Pause Menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject _pauseCanvas;
	[SerializeField] private AudioMixerSnapshot _unPaused, _paused;
	public static bool gameIsPaused = false;
	[SerializeField] private PlayerInputs _playerInputs;

	void Update()
	{
		GameState();
	}

	// Resume or pause the game on menu input
	private void GameState()
	{
		if (_playerInputs.menuInput)
		{
			if (gameIsPaused)
			{
				Resume();
			}
			else if (!gameIsPaused)
			{
				Pause();
			}

			_playerInputs.menuInput = false;
		}
	}

	/// <summary>
	/// Pause the game
	/// </summary>
	public void Pause()
	{
		_pauseCanvas.SetActive(true);
		Time.timeScale = 0f;
		Cursor.lockState = CursorLockMode.None;
		gameIsPaused = true;
		_paused.TransitionTo(0f);
	}

	/// <summary>
	/// Resume the game
	/// </summary>
	public void Resume()
	{
		_pauseCanvas.SetActive(false);
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		gameIsPaused = false;
		_unPaused.TransitionTo(0f);
	}

	/// <summary>
	/// Restart actual level
	/// </summary>
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	/// <summary>
	/// Leads to MainMenu scene
	/// </summary>
	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	/// <summary>
	/// Go to Options scene and get last scene
	/// </summary>
	public void Options()
	{
		PlayerPrefs.SetInt("last_scene", SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene(1);
	}
}
