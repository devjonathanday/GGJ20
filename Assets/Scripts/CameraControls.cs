using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Camera cam;
    public float zoomSpeed;
    public Vector2 zoomBounds;
    public float rotationSpeed;

    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cam.orthographicSize += zoomSpeed;
            if (cam.orthographicSize > zoomBounds.y) cam.orthographicSize = zoomBounds.y;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.orthographicSize -= zoomSpeed;
            if (cam.orthographicSize < zoomBounds.x) cam.orthographicSize = zoomBounds.x;
        }
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
    }
}