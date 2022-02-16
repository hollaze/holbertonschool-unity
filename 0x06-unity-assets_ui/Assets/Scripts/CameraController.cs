using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera Controller
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 150f;
    private float xRotation = 0f;
    public bool isInverted = false;

    // Update is called once per frame
    void Update()
    {
        MouseX();

        // OptionsMenu.cs -> Apply()
        if (PlayerPrefs.GetInt("invertYToggleState") == 0)
        {
            MouseY();
        }
        else if (PlayerPrefs.GetInt("invertYToggleState") == 1)
        {
            MouseYInverted();
        }
    }

    /// <summary>
    /// Mouse X rotation
    /// </summary>
    public void MouseX()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Rotate player on Y axis when mouse goes
        // From left to right - mouseX axis
        playerBody.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// Mouse Y rotation
    /// </summary>
    public void MouseY()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 0.6f * Time.deltaTime;

        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -2.5f, 30f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    /// <summary>
    /// Inverted Mouse in Y
    /// </summary>
    public void MouseYInverted()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 0.6f * Time.deltaTime;

        xRotation = xRotation + mouseY;
        xRotation = Mathf.Clamp(xRotation, -2.5f, 30f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
