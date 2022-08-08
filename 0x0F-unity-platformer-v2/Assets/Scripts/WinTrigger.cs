using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Trigger to touch for user to win
/// </summary>
public class WinTrigger : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _BackgroundMusic;
    private Transform _levelMusic, _victoryPiano;
    public static bool win = false;


    void Start()
    {
        _levelMusic = _BackgroundMusic.transform.GetChild(0);
        _victoryPiano = _BackgroundMusic.transform.GetChild(1);
    }

    // Timer stop, activate win canvas
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _winCanvas.SetActive(true);
            _levelMusic.gameObject.SetActive(false);
            _victoryPiano.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            _player.GetComponent<Timer>().StopAllCoroutines();

            win = true;
            Time.timeScale = 0f;
            PauseMenu.gameIsPaused = true;
        }
    }
}
