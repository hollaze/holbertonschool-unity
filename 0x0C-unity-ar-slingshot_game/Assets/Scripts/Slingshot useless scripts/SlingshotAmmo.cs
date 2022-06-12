using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotAmmo : MonoBehaviour
{
	public Camera m_Camera;
	public GameObject center, ammo;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
		this.transform.rotation = Quaternion.LookRotation(ray.origin, Vector3.up);
		ammo.transform.LookAt(center.transform);
	}
}
