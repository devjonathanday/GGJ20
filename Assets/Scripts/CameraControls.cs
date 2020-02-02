using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Camera cam;
    public Vector3 camDefaultPos;
    public float zoomSpeed;
    public Vector2 zoomBounds;
    public float rotationSpeed;

    public float shakeAmount;
    public float shakeTimer;
    public float currentShakeTimer;

    void Start()
    {
        camDefaultPos = cam.transform.localPosition;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
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

        if (currentShakeTimer > 0)
        {
            currentShakeTimer -= Time.deltaTime;
            if (currentShakeTimer <= 0) currentShakeTimer = 0;

            Vector3 shakeDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            cam.transform.localPosition = camDefaultPos + shakeDirection * shakeAmount * currentShakeTimer;
        }

        if (Input.GetKeyDown(KeyCode.L)) Shake();
    }

    void Shake()
    {
        currentShakeTimer = shakeTimer;
    }
}