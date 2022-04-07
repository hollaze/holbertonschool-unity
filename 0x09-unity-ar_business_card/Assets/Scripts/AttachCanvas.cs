using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCanvas : MonoBehaviour
{
    public Transform imageTarget;

    private void LateUpdate()
    {
        this.gameObject.transform.position = imageTarget.transform.position;
    }
}
