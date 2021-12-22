using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed;
    public int health = 5;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        speed = speed * 100f;
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
        m_Rigidbody.AddForce(playerMovement);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("<color=#DE4B00>Game Over!</color>");
            SceneManager.LoadScene("maze");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            Debug.Log($"<color=#FFFF00>Score: {score}</color>");
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health -= 1;
            Debug.Log($"<color=#FF0000>Health {health}</color>");
        }
        if (other.tag == "Goal")
        {
            Debug.Log("<color=#00FF00>You win!</color>");
        }
    }
}
