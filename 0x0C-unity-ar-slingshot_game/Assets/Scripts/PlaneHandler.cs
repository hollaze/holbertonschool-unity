using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneHandler : MonoBehaviour
{
	public ARPlane m_ARPlane;

	/*#region Singleton
	public static PlaneHandler Instance;
	#endregion

	private void Awake()
	{
		#region Singleton
		if (Instance != null)
		{
			Debug.LogWarning("PlaneHandler Singleton Instance is not null");
			return;
		}

		Instance = this;
		#endregion
	}*/

	private void Update()
	{
		PrintDetectionPlaneMode();
	}

	#region UI
	// Print detection plane mode
	private void PrintDetectionPlaneMode()
	{
		if (m_ARPlane.trackingState.ToString() == "None")
		{
			PlaneDetectionUI.Instance.planeDetectionText.text = "Searching for a plane...";
		}
		else if (m_ARPlane.trackingState.ToString() == "Tracking")
		{
			PlaneDetectionUI.Instance.planeDetectionBackgroundImage.color = Color.green;
			PlaneDetectionUI.Instance.planeDetectionText.text = "Select a plane";
		}
	}
	#endregion
}
