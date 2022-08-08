using UnityEngine.SceneManagement;
using UnityEngine;

public class RebindingMenu : MonoBehaviour
{
	/// <summary>
	/// Load Options scene
	/// </summary>
	public void Back()
	{
		SceneManager.LoadScene("Options");
	}
}
