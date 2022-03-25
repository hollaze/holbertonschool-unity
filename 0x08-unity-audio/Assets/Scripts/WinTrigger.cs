using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Trigger to touch for user to win
/// </summary>
public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    public GameObject player;
    public GameObject winCanvas;
    public GameObject BackgroundMusic;
    private Transform CheeryMonday, VictoryPiano;
    public static bool win = false;


    void Start()
    {
        CheeryMonday = BackgroundMusic.transform.GetChild(0);
        VictoryPiano = BackgroundMusic.transform.GetChild(1);
    }

    // Timer stop, activate win canvas
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            winCanvas.SetActive(true);
            CheeryMonday.gameObject.SetActive(false);
            VictoryPiano.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<Timer>().StopAllCoroutines();

            win = true;
            Time.timeScale = 0f;
            PauseMenu.gameIsPaused = true;
        }
    }
}
