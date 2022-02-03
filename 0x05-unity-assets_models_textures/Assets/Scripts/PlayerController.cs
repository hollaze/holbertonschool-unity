using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Transform fallCheck;

    private Vector3 playerVelocity;
    public float gravity = -9.81f;
    public float playerSpeed = 10f;
    public float playerJumpHeight = 5f;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        FallFromWorld();

        // Reset velocity if player is grounded
        // otherwise, velocity continues to adding gravity
        // infinitely even when player is not falling
        if (IsGrounded() && playerVelocity.y < 0)
        {
            // -2f pushes the player against the ground
            // works better than 0f
            playerVelocity.y = -2f;
        }

        Movements();
        Jump();
    }

    void Movements()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Player movements
        Vector3 playerMove = transform.right * x + transform.forward * z;
        characterController.Move(playerMove * playerSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // Player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravity);
        }

        // Apply gravity to player
        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    // Check if player is grounded
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
    }

    void FallFromWorld()
    {
        if (characterController.transform.position.y <= fallCheck.position.y)
        {
            characterController.enabled = false;
            characterController.transform.position = new Vector3(0, 100, 0);
            characterController.enabled = true;
        }
        characterController.velocity.Set(0, 0, 0);
    }
}
