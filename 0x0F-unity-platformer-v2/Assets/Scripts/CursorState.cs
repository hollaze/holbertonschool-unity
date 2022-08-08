using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorState : MonoBehaviour
{
    private int _actualScene;

    void Awake()
    {
        _actualScene = SceneManager.GetActiveScene().buildIndex;

        if (_actualScene > 2)
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
