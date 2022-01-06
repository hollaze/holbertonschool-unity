using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Control player movements.
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed;
    public int health = 5;
    private int score = 0;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseImage;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        if (health == 0)
        {
            SetLoseText();
            StartCoroutine(LoadScene(3));
        }
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            SetWinText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    void SetWinText()
    {
        winLoseText.color = Color.black;
        winLoseText.text = "You Win!";
        winLoseImage.color = Color.green;
        winLoseImage.gameObject.SetActive(true);
    }

    void SetLoseText()
    {
        winLoseText.color = Color.white;
        winLoseText.text = "Game Over!";
        winLoseImage.color = Color.red;
        winLoseImage.gameObject.SetActive(true);
    }
}
