using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float time;
    private float minutes;
    private float seconds;
    private float milliseconds;

    // Start is called before the first frame update
    void Start()
    {
        // Why putting corouting in Start
        StartCoroutine(InGameTimer());
    }

    // Ok, I don't understand
    IEnumerator InGameTimer()
    {
        while (true)
        {
            // Actual time, adding everytime
            time += Time.deltaTime;
            minutes = (int)(time / 60 % 60);
            seconds = (int)(time % 60);
            // Why time - time
            milliseconds = (int)((time - (int)time) * 100);

            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);

            yield return null;
        }
    }
}
