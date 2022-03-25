using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    private Transform camTransform;
    public bool isInverted = false;
    private float cameraDistance = -6.25f;
    private float mouseX, mouseY, mouseSensivity = 100f;

    void Awake()
    {
        isInverted = (PlayerPrefs.GetInt("invertYToggleState") == 0 ? true : false);
    }

    void Start()
    {
        camTransform = GetComponent<Transform>();
    }

    void MouseX()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
    }

    void MouseY()
    {
        mouseY += Input.GetAxis("Mouse Y") * (isInverted ? 1 : -1) * mouseSensivity * 0.6f * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -2.5f, 30f);
    }

    void Update()
    {
        MouseX();
        MouseY();
    }

    void CameraPositionRotation()
    {
        Vector3 dir = new Vector3(0, 0, cameraDistance);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        camTransform.position = playerBody.position + rotation * dir;
        camTransform.LookAt(playerBody.position);
    }

    private void LateUpdate()
    {
        CameraPositionRotation();
    }
}