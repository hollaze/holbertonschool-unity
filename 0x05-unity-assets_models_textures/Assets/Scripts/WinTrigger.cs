using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    public GameObject player;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            timerText.color = Color.green;
            timerText.fontSize = 60;
            player.GetComponent<Timer>().StopAllCoroutines();
        }
    }
}
