using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Ammo : MonoBehaviour
{
	#region Shoot
	private Vector3 _mousePressDownPos, _mouseReleasePos;
	private Rigidbody _rigidoby;
	private bool _isShoot;
	private float _forceMultiplier = 6f;
	#endregion

	private void Awake()
	{
		_rigidoby = GetComponent<Rigidbody>();
	}

	private void OnMouseDown()
	{
		#region Shoot
		_mousePressDownPos = Input.mousePosition;
		#endregion
	}

	private void OnMouseUp()
	{
		#region Shoot
		_mouseReleasePos = Input.mousePosition;
		Shoot(_mousePressDownPos - _mouseReleasePos);
		#endregion
	}

	#region Shoot
	// Shoot the ball with force
	private void Shoot(Vector3 force)
	{
		if (_isShoot) return;

		_rigidoby.AddForce(new Vector3(force.x, force.y, force.z) * _forceMultiplier * Time.deltaTime);
		_isShoot = true;
	}
	#endregion
}
