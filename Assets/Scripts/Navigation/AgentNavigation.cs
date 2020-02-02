using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    private Vector3 goalLocation;

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


    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void GoToDestination()
    {
        agent.SetDestination(goalLocation);
    }

}
