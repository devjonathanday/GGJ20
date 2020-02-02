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
    public GameObject explosion;

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
    void Start()
    {
        Time.timeScale = 1;
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
        Instantiate(explosion, transform.position, Quaternion.identity);
        LossConditions.WorkersLeft--;
        Destroy(gameObject);
    }
}
