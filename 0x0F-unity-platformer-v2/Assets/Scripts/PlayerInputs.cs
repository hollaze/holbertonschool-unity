using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
	public Vector2 playerMovements { get; set; }
	public bool jumpInput { get; set; }
	public bool menuInput { get; set; }

	private void Awake()
	{
		jumpInput = false;
		menuInput = false;
	}

	private void OnMove(InputValue iv)
	{
		playerMovements = iv.Get<Vector2>();
	}

	private void OnJump(InputValue iv)
	{
		jumpInput = iv.isPressed;
	}

	private void OnMenu(InputValue iv)
	{
		menuInput = iv.isPressed;
	}
}
