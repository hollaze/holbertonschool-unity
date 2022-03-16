using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public GameObject m_MainCamera;
    public GameObject m_Player;
    public GameObject m_TimerCanvas;
    private Animator m_CutsceneCameraAnimator;

    void Start()
    {
        m_CutsceneCameraAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        string actualScene = SceneManager.GetActiveScene().name;

        switch (actualScene)
        {
            case "Level01":
                m_CutsceneCameraAnimator.SetBool("Level01", true);
                m_CutsceneCameraAnimator.SetBool("Level02", false);
                m_CutsceneCameraAnimator.SetBool("Level03", false);
                break;
            case "Level02":
                m_CutsceneCameraAnimator.SetBool("Level01", false);
                m_CutsceneCameraAnimator.SetBool("Level02", true);
                m_CutsceneCameraAnimator.SetBool("Level03", false);
                break;
            case "Level03":
                m_CutsceneCameraAnimator.SetBool("Level01", false);
                m_CutsceneCameraAnimator.SetBool("Level02", false);
                m_CutsceneCameraAnimator.SetBool("Level03", true);
                break;
        }
    }

    public void cutSceneEnd()
    {
        m_TimerCanvas.SetActive(true);
        m_MainCamera.SetActive(true);
        m_Player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }
}
