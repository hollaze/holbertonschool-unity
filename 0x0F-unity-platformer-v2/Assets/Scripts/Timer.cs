using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Timer
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _finalTimeText;
    private float _time;
    private float _minutes;
    private float _seconds;
    private float _milliseconds;

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
            _time += Time.deltaTime;
            _minutes = (int)(_time / 60 % 60);
            _seconds = (int)(_time % 60);
            _milliseconds = (int)((_time - (int)_time) * 100);

            _timerText.text = string.Format("{0:0}:{1:00}.{2:00}", _minutes, _seconds, _milliseconds);

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
            _finalTimeText.text = _timerText.text;
            _timerText.gameObject.SetActive(false);
        }
    }
}
