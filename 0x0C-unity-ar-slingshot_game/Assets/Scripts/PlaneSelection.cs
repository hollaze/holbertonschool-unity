using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSelection : MonoBehaviour
{
	private Renderer _renderer;
	public ARPlaneManager planeManager;
	private static ARPlane selectedPlane;
	private bool isPlaneSelected = false;
	public Vector2 planeSize { get; private set; }

	private void Awake()
	{
		_renderer = GetComponent<Renderer>();
		selectedPlane = GetComponent<ARPlane>();
	}

	private void OnMouseDown()
	{
		if (isPlaneSelected == false)
		{
			isPlaneSelected = true;

			_renderer.material.color = Color.red;

			PlaneDetectionUI.Instance.planeDetectionBackgroundImage.gameObject.SetActive(false);
			PlaneDetectionUI.Instance.startButton.gameObject.SetActive(true);

			planeSize = selectedPlane.size;
		}
	}

	private void Update()
	{
		// Disabling and deactivate renderer on not selected planes
		if (isPlaneSelected == true && planeManager.enabled == true)
		{
			foreach (ARPlane plane in planeManager.trackables)
			{
				if (plane.gameObject.GetComponent<Renderer>().material.color != Color.red)
				{
					plane.gameObject.SetActive(false);
				}
			}

			// Making sure no other planes will be enabled
			planeManager.enabled = false;
		}
	}
}
