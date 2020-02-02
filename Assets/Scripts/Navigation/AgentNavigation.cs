using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavigation : MonoBehaviour
{
    public Repair repair;
    public NavMeshAgent agent;
    private Vector3 goalLocation;
    public GameObject selectedUI;

    public Vector3 GoalLocation
    {
        get => goalLocation;
        set
        {
            if (value != null)
            {
                goalLocation = value;
                GoToDestination();
            }          
        }
    }


    void Update()
    {
        if (agent.isStopped == false)
        {
            if (agent.velocity.magnitude > 1)
            {
                if (agent.remainingDistance <= 3)
                {
                    if (repair.RepairFlag != true)
                    {
                        repair.RepairFlag = true;
                    }
                }
            }
        }
    }

    public void GoToDestination()
    {
        agent.SetDestination(goalLocation);
    }
    public void SetSelected()
    {
        selectedUI.SetActive(true);
    }
    public void SetDeselected()
    {
        selectedUI.SetActive(false);
    }
    public void Death()
    {
        LossConditions.WorkersLeft--;
    }
}
