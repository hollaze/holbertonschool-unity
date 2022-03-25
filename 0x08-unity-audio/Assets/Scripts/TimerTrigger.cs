using UnityEngine;

/// <summary>
/// Trigger the timer
/// </summary>
public class TimerTrigger : MonoBehaviour
{
    public GameObject player;

    // Start enable Timer script
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
