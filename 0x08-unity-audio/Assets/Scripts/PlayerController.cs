using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Player Controller
/// </summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Transform fallCheck;
    public Animator playerAnimator;
    private AnimatorClipInfo[] m_CurrentClipInfo;


    private string m_ClipName;
    private Vector3 playerVelocity;
    public float gravity = -9.81f;
    public float playerSpeed = 10f;
    public float playerRotationSpeed = 100f;
    public float playerJumpHeight = 5f;
    private bool playerFell = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //DetectTouchingPlatform();
        FallFromWorld();

        // Reset velocity if player is grounded
        // otherwise, velocity continues to adding gravity
        // infinitely even when player is not falling
        if (IsGrounded() && playerVelocity.y < 0)
        {
            // -2f pushes the player against the ground
            // works better than 0f
            playerVelocity.y = -2f;

            if (playerFell == true)
            {
                TouchingWorld();
            }
        }

        Movements();
        Jump();
    }

    // Player movements
    void Movements()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Player movements
        Vector3 playerMove = transform.forward * z;
        characterController.Move(playerMove * playerSpeed * Time.deltaTime);

        characterController.transform.Rotate(Vector3.up * x * playerRotationSpeed * Time.deltaTime);

        // Player running animation
        if (playerMove == Vector3.zero && IsGrounded())
        {
            playerAnimator.SetBool("isMoving", false);
        }
        else if (playerMove.x != 0 || playerMove.z != 0 && IsGrounded())
        {
            playerAnimator.SetBool("isMoving", true);
        }
    }

    // Player jump
    void Jump()
    {
        // Player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravity);
        }

        if (!IsGrounded())
        {
            playerAnimator.SetBool("Jumping", true);
        }
        else
        {
            playerAnimator.SetBool("Jumping", false);
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

    // Check if player fell from the world and then change
    // his position and reset his velocity
    void FallFromWorld()
    {
        m_CurrentClipInfo = this.playerAnimator.GetCurrentAnimatorClipInfo(0);
        m_ClipName = m_CurrentClipInfo[0].clip.name;

        if (characterController.transform.position.y <= fallCheck.position.y)
        {
            // Teleport player in Y position
            characterController.enabled = false;
            characterController.transform.position = new Vector3(0, 100, 0);
            characterController.enabled = true;

            playerAnimator.SetBool("Falling", true);
            playerFell = true;
        }

        characterController.velocity.Set(0, 0, 0);

        // Stop player from moving on animation
        if (m_ClipName == "Falling" ||
            m_ClipName == "Falling Flat Impact" ||
            m_ClipName == "Getting Up")
        {
            playerSpeed = 0f;
            playerRotationSpeed = 0f;
            playerJumpHeight = 0f;
        }
        else
        {
            playerSpeed = 10f;
            playerRotationSpeed = 100f;
            playerJumpHeight = 5f;
        }
    }

    // Player touching the world after falling from it
    void TouchingWorld()
    {
        playerAnimator.SetBool("Falling", false);
        playerFell = false;
    }
}
