using UnityEngine;

/// <summary>
/// Player Controller
/// </summary>

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	private CharacterController _characterController;
	[SerializeField] private Transform _mainCamera;

	// Check floor
	[SerializeField] private Transform _groundCheck;
	[SerializeField] private LayerMask _groundMask;

	// Falling check
	[SerializeField] private Transform _fallCheck;
	private bool _playerFell = false;

	// Animations
	public static Animator playerAnimator;
	public static AnimatorClipInfo[] m_CurrentClipInfo;
	public static string m_ClipName;

	// Player movements
	[SerializeField] private float _turnSmoothTime = 0.1f;
	private float _turnSmoothVelocity;
	[SerializeField] private float _speed = 5f;

	// Gravity and Jump
	[SerializeField] private float _gravity = -9.81f;
	private Vector3 _playerVelocity;
	[SerializeField] private float _jumpHeight = 3f;

	// Inputs
	[SerializeField] private PlayerInputs _playerInputs;

	private void Start()
	{
		_characterController = GetComponent<CharacterController>();
		playerAnimator = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update()
	{
		//DetectTouchingPlatform();
		FallFromWorld();

		// Reset velocity if player is grounded
		// otherwise, velocity continues to adding gravity
		// infinitely even when player is not falling
		if (IsGrounded() && _playerVelocity.y < 0)
		{
			// -2f pushes the player against the ground
			// works better than 0f
			_playerVelocity.y = -2f;

			if (_playerFell == true)
			{
				TouchingWorld();
			}
		}

		MovePlayer();
		Jump();
	}

	// Player movements
	private void MovePlayer()
	{
		Vector3 direction = new Vector3(_playerInputs.playerMovements.x, 0f, _playerInputs.playerMovements.y).normalized;

		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 _movementDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

			_characterController.Move(_movementDirection.normalized * _speed * Time.deltaTime);
		}

		isPlayerRunning();
	}

	/*private void OnMove(InputValue iv)
	{
		_playerMovements = iv.Get<Vector2>();
	}*/

	void isPlayerRunning()
	{
		// Player running animation
		if (_playerInputs.playerMovements == Vector2.zero && IsGrounded())
		{
			playerAnimator.SetBool("isMoving", false);
		}
		else if (_playerInputs.playerMovements.x != 0 || _playerInputs.playerMovements.y != 0 && IsGrounded())
		{
			playerAnimator.SetBool("isMoving", true);
		}
	}

	// Player jump
	void Jump()
	{
		// Player jump
		if (_playerInputs.jumpInput && IsGrounded())
		{
			_playerVelocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);

			_playerInputs.jumpInput = false;
		}

		isPlayerJumping();

		// Apply gravity to player
		_playerVelocity.y += _gravity * Time.deltaTime;
		_characterController.Move(_playerVelocity * Time.deltaTime);
	}

	/*private void OnJump(InputValue iv)
	{
		_jumpButton = iv.isPressed;
	}*/

	void isPlayerJumping()
	{
		if (!IsGrounded())
		{
			playerAnimator.SetBool("Jumping", true);
		}
		else
		{
			playerAnimator.SetBool("Jumping", false);
		}
	}

	// Check if player is grounded
	bool IsGrounded()
	{
		return Physics.CheckSphere(_groundCheck.position, 0.25f, _groundMask);
	}

	// Check if player fell from the world and then change
	// his position and reset his velocity
	void FallFromWorld()
	{
		_characterController.velocity.Set(-_characterController.velocity.x, 0, -_characterController.velocity.z);

		m_CurrentClipInfo = playerAnimator.GetCurrentAnimatorClipInfo(0);
		m_ClipName = m_CurrentClipInfo[0].clip.name;

		if (_characterController.transform.position.y <= _fallCheck.position.y)
		{
			// Teleport player in Y position
			_characterController.enabled = false;
			_characterController.transform.position = new Vector3(0, 100, 0);
			_characterController.enabled = true;

			playerAnimator.SetBool("Falling", true);
			_playerFell = true;
		}

		// Stop player moving on animation
		if (m_ClipName == "Falling" ||
			m_ClipName == "Falling Flat Impact" ||
			m_ClipName == "Getting Up")
		{
			_speed = 0f;
			_jumpHeight = 0f;
		}
		else
		{
			_speed = 5f;
			_jumpHeight = 3f;
		}
	}

	// Player touching the world after falling from it
	void TouchingWorld()
	{
		playerAnimator.SetBool("Falling", false);
		_playerFell = false;
	}
}
