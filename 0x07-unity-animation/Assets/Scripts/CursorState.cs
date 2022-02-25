using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorState : MonoBehaviour
{
    private string actualScene;

    void Awake()
    {
        actualScene = SceneManager.GetActiveScene().name;

        if (actualScene == "MainMenu" || actualScene == "Options")
        {
            CursorUnlock();
        }
        else
        {
            CursorLock();
        }
    }

    /// <summary>
    /// Cursor is locked
    /// </summary>
    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    /// <summary>
    /// Cursor is unlocked
    /// </summary>
    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
