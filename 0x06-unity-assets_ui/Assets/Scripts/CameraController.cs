using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        
        // Rotate player on Y axis when mouse goes
        // From left to right - mouseX axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
