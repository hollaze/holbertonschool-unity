using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaneDetectionUI : MonoBehaviour
{
	#region Singleton
	public static PlaneDetectionUI Instance;
	#endregion

	#region UI
	public TextMeshProUGUI planeDetectionText;
	public Image planeDetectionBackgroundImage;
	public Button startButton;
	public TextMeshProUGUI nombreInstances;
	#endregion


	private void Awake()
	{
		if (Instance != null)
		{
			Debug.LogWarning("PlaneDetectionUI Singleton Instance is not null");
			return;
		}

		Instance = this;
	}
}
