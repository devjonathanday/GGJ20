using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSelection : MonoBehaviour
{
    [Header("Selection Properties")]
    public List<AgentNavigation> selectedAgents = new List<AgentNavigation>();
    public Camera cam;

    [Header("Projection Properties")]
    public LayerMask agentLayers;
    public LayerMask targetableLayers;
    public float raycastDistance;

    public GameObject[] testObjects;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, raycastDistance, agentLayers))
            {
                //Select multiple
                if (Input.GetKey(KeyCode.LeftControl) ||
                   Input.GetKey(KeyCode.RightControl) ||
                   Input.GetKey(KeyCode.LeftShift) ||
                   Input.GetKey(KeyCode.RightShift))
                {
                    if(!selectedAgents.Contains(hit.collider.gameObject.GetComponent<AgentNavigation>()))
                        selectedAgents.Add(hit.collider.gameObject.GetComponent<AgentNavigation>());
                }
                //Select singular
                else
                {
                    selectedAgents.Clear();
                    selectedAgents.Add(hit.collider.gameObject.GetComponent<AgentNavigation>());
                }
            }
            //Deselect
            else
            {
                selectedAgents.Clear();
            }
        }

        //Set target of selected agents
        if (Input.GetMouseButtonDown(1) && selectedAgents.Count > 0)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, raycastDistance, targetableLayers))
            {
                if (hit.collider.gameObject.CompareTag("Machine"))
                {
                    //Vector3[] targets = new Vector3[9];
                }
                //Check if machine
                //  Place the agents around the machine, evenly spaced
                //Else, just move to the position
                SetTarget(hit.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < testObjects.Length; i++)
            {
                float increment = (float)(i+1) / (float)testObjects.Length;
                Debug.Log(increment);
                //testObjects[i].transform.position = (i / testObjects.Length)
            }
        }
    }

    void SetTarget(Vector3 target)
    {
        for (int i = 0; i < selectedAgents.Count; i++)
            selectedAgents[i].GoalLocation = target;

        selectedAgents.Clear();
    }
}