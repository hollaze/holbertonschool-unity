using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
	private Rigidbody rb;
	private Vector3 offset = Vector3.zero;
	private float mousePosZ;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnMouseDown()
	{
		mousePosZ = Camera.main.WorldToScreenPoint(transform.position).z;

		offset = transform.position - MouseWorldPosition();
	}

	private Vector3 MouseWorldPosition()
	{
		Vector3 mousePos = Input.mousePosition;

		mousePos.z = mousePosZ;

		return Camera.main.ScreenToWorldPoint(mousePos);
	}

	private void OnMouseDrag()
	{
		transform.position = MouseWorldPosition() + offset;

		rb.isKinematic = true;
	}

	private void OnMouseUp()
	{
		rb.isKinematic = false;
	}
}
