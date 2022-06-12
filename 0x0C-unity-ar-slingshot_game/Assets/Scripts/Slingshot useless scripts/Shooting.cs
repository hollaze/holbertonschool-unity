using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	//public GameObject ammo;
	public Rigidbody ammoRb;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetButton("Fire1"))
		{
			ammoRb.isKinematic = false;
			ammoRb.transform.parent = null;
			ammoRb.useGravity = true;
			ammoRb.AddForce(ammoRb.transform.forward * 0.3f, ForceMode.Impulse);

			Slingshot.instance.leftLine.enabled = false;
			Slingshot.instance.rightLine.enabled = false;
		}
	}
}

