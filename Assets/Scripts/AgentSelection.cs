﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSelection : MonoBehaviour
{
    [Header("Selection Properties")]
    public List<AgentNavigation> selectedAgents = new List<AgentNavigation>();
    public Camera cam;
    public int maxAgentsPerMachine;

    [Header("Projection Properties")]
    public LayerMask agentLayers;
    public LayerMask targetableLayers;
    public float raycastDistance;

    public float distance;
    void Start()
    {
        LossConditions.WorkersLeft = GameObject.FindGameObjectsWithTag("Agent").Length;
    }

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
                    if (!selectedAgents.Contains(hit.collider.gameObject.GetComponent<AgentNavigation>()))
                    {
                        selectedAgents.Add(hit.collider.gameObject.GetComponent<AgentNavigation>());
                        selectedAgents[selectedAgents.Count - 1].SetSelected();
                    }
                }
                //Select singular
                else
                {
                    for (int i = 0; i < selectedAgents.Count; i++)
                        selectedAgents[i].SetDeselected();
                        selectedAgents.Clear();

                    selectedAgents.Add(hit.collider.gameObject.GetComponent<AgentNavigation>());
                    selectedAgents[selectedAgents.Count - 1].SetSelected();
                }
            }
            //Deselect
            else
            {
                if (!Input.GetKey(KeyCode.LeftControl)  &&
                    !Input.GetKey(KeyCode.RightControl) &&
                    !Input.GetKey(KeyCode.LeftShift)    &&
                    !Input.GetKey(KeyCode.RightShift))
                {
                    for (int i = 0; i < selectedAgents.Count; i++)
                        selectedAgents[i].SetDeselected();
                        selectedAgents.Clear();
                }
            }
        }

        //Set target of selected agents
        if (Input.GetMouseButtonDown(1) && selectedAgents.Count > 0)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, raycastDistance, targetableLayers))
            {
                if (hit.collider.gameObject.CompareTag("Machine"))
                {
                    int agentsToSend = Mathf.Min(selectedAgents.Count, maxAgentsPerMachine);
                    for (int i = 0; i < agentsToSend; i++)
                    {
                        float increment = ((float)(i + 1) / (float)agentsToSend) * Mathf.PI * 2;
                        selectedAgents[i].GoalLocation = hit.transform.position + new Vector3(Mathf.Sin(increment) * distance, 0, Mathf.Cos(increment) * distance);
                    }
                }
                else
                {
                    for (int i = 0; i < selectedAgents.Count; i++)
                        selectedAgents[i].GoalLocation = hit.point;
                }
                for (int i = 0; i < selectedAgents.Count; i++)
                    selectedAgents[i].SetDeselected();
                selectedAgents.Clear();
            }
        }
    }

    //public void EvaluateWorkers()
    //{
    //    for (int i = 0; i < selectedAgents.Count; i++)
    //        if (selectedAgents[i] == null) selectedAgents.RemoveAt(i);
    //}
}