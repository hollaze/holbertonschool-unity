using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; // Distance between player and camera

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
