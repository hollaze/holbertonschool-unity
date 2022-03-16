using System.Collections;
using System.Collections.Generic;
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
    public static bool win = false;

    // Timer stop, activate win canvas
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            winCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<Timer>().StopAllCoroutines();

            win = true;
            Time.timeScale = 0f;
            PauseMenu.gameIsPaused = true;
        }
    }
}
