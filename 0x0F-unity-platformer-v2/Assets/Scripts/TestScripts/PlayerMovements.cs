using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovements : MonoBehaviour
{
	private CharacterController _characterController;
	[SerializeField] private float _speed = 5f;
	private float _speedMultiplier = 100f;
	private Vector2 _playerMovements = Vector2.zero;

	[SerializeField] private float _rotationSpeed = 720f;

	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		Vector3 movementDirection = new Vector3(_playerMovements.x, 0, _playerMovements.y);

		movementDirection.Normalize();

		_characterController.SimpleMove(movementDirection * _speed * _speedMultiplier * Time.deltaTime);

		if (movementDirection != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

			_characterController.transform.rotation = Quaternion.RotateTowards(_characterController.transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
		}
	}

	private void OnMove(InputValue iv)
	{
		_playerMovements = iv.Get<Vector2>();
	}
}
