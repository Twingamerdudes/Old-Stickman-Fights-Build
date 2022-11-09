using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [Header("Camera Follow")]
    public Camera cam;
    [Range(0f, 1f)] public float interpolation = 0.1f;
    public Vector3 offset = new Vector3(0f, 2f, -10f);

    private void CameraFollow()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offset, interpolation);
    }


    private void FixedUpdate()
    {
        CameraFollow();
    }
}
