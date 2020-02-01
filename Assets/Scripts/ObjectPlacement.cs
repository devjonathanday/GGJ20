using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    [Header("Object Properties")]
    public float objectHeight;

    [Header("References")]
    public GameObject focusedObject;
    public Camera cam;

    [Header("Projection Properties")]
    public LayerMask placeableLayers;
    public float raycastDistance;

    void Update()
    {
        if (focusedObject)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, raycastDistance, placeableLayers))
                focusedObject.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), hit.point.y, Mathf.RoundToInt(hit.point.z));
        }
        if(Input.GetMouseButtonDown(0))
        {
            TryFinishPlacement();
        }
    }

    public void StartNewPlacement(GameObject objectPrefab)
    {
        if (!focusedObject)
        {
            ulong neededCost = objectPrefab.GetComponent<MoneyMachine>().Cost;
            if (PlayerPocket.Money >= neededCost)
            {
                GameObject newObject = Instantiate(objectPrefab);
                focusedObject = newObject;
            }

        }
    }

    public void TryFinishPlacement()
    {
        if (focusedObject && Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, raycastDistance, placeableLayers))
        {
            PlayerPocket.Money -= focusedObject.GetComponent<MoneyMachine>().Cost;
            focusedObject.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), hit.point.y, Mathf.RoundToInt(hit.point.z));
            focusedObject = null;
            
        }
    }
}