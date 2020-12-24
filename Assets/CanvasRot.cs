using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CanvasRot : NetworkBehaviour
{
    public Transform mainCameraTransform;
    void Start()
    {
        InvokeRepeating("CamTransform", 0.1f, 0.2f);
    }

    private void CamTransform()
    {
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
    }
}
