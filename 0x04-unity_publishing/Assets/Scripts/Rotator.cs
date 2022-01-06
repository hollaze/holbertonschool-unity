using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotate coin game object.
/// </summary>
public class Rotator : MonoBehaviour
{
    GameObject coin;
    float x_rotation = 45f;

    void Update()
    {
        transform.Rotate(x_rotation * Time.deltaTime, 0, 0);
    }
}
