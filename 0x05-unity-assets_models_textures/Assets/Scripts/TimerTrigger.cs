using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            player.GetComponent<Timer>().enabled = true;
            GetComponent<TimerTrigger>().enabled = false;
        }
    }

}
