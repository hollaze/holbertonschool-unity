using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Timer
/// </summary>
public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text finalTimeText;
    private float time;
    private float minutes;
    private float seconds;
    private float milliseconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InGameTimer());
    }
    
    void Update()
    {
        Win();
    }

    /// <summary>
    /// Timer
    /// </summary>
    /// <returns> null </returns>
    IEnumerator InGameTimer()
    {
        while (true)
        {
            // Actual time, adding everytime
            time += Time.deltaTime;
            minutes = (int)(time / 60 % 60);
            seconds = (int)(time % 60);
            milliseconds = (int)((time - (int)time) * 100);

            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);

            yield return null;
        }
    }

    /// <summary>
    /// When player win
    /// </summary>
    public void Win()
    {
        if (WinTrigger.win)
        {
            WinTrigger.win = false;
            finalTimeText.text = timerText.text;
            timerText.gameObject.SetActive(false);
        }
    }
}
