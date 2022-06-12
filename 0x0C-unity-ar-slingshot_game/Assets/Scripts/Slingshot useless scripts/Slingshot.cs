using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
	// Singleton
	public static Slingshot instance;

	public LineRenderer rightLine, leftLine;
	public GameObject ammo;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than one Slingshot instance");
			return;
		}

		instance = this;
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		LinesToAmmo();
	}

	// Join line renderers from the slingshot to the ammo
	private void LinesToAmmo()
	{
		rightLine.SetPositions(new Vector3[] { rightLine.transform.position, ammo.transform.position });
		leftLine.SetPositions(new Vector3[] { leftLine.transform.position, ammo.transform.position });
	}
}

