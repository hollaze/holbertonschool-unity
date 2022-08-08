using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _timerCanvas;
    private Animator _cutsceneCameraAnimator;

    void Start()
    {
        _cutsceneCameraAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        string actualScene = SceneManager.GetActiveScene().name;

        switch (actualScene)
        {
            case "Level01":
                _cutsceneCameraAnimator.SetBool("Level01", true);
                _cutsceneCameraAnimator.SetBool("Level02", false);
                _cutsceneCameraAnimator.SetBool("Level03", false);
                break;
            case "Level02":
                _cutsceneCameraAnimator.SetBool("Level01", false);
                _cutsceneCameraAnimator.SetBool("Level02", true);
                _cutsceneCameraAnimator.SetBool("Level03", false);
                break;
            case "Level03":
                _cutsceneCameraAnimator.SetBool("Level01", false);
                _cutsceneCameraAnimator.SetBool("Level02", false);
                _cutsceneCameraAnimator.SetBool("Level03", true);
                break;
        }
    }

    public void cutSceneEnd()
    {
        _timerCanvas.SetActive(true);
        _mainCamera.SetActive(true);
        _player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }
}
