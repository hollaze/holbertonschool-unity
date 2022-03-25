using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorState : MonoBehaviour
{
    private int actualScene;

    void Awake()
    {
        actualScene = SceneManager.GetActiveScene().buildIndex;

        if (actualScene > 1)
        {
            CursorLock();
        }
        else
        {
            CursorUnlock();
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
