using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    [Header("Object Properties")]
    public Transform myObject;
    public float objectHeight;
    public Transform cam;
    public LayerMask placeableLayers;
    public float raycastDistance;

    void Start()
    {

    }

    void Update()
    {
        if(Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, raycastDistance, placeableLayers))
        {
            myObject.position = new Vector3(Mathf.RoundToInt(hit.point.x), hit.point.y + (objectHeight / 2), Mathf.RoundToInt(hit.point.z));
        }
    }
}