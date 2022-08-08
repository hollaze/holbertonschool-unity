using UnityEngine;

/// <summary>
/// Trigger the timer
/// </summary>
public class TimerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    // Start enable Timer script
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            _player.GetComponent<Timer>().enabled = true;
            GetComponent<TimerTrigger>().enabled = false;
        }
    }
}
