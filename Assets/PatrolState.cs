using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public override void EnterState(AgentController theAgent)
    {
        Debug.Log("Patrol");
        theAgent.MeshRenderer.material.color = Color.green;
    }

    public override void OnCollistionEnter(AgentController theAgent)
    {
        
    }

    public override void Update(AgentController theAgent)
    {
        Vector3 neighborhood = theAgent.transform.position - theAgent.myCube.transform.position;
       // Debug.Log(neighborhood.magnitude);
        if(neighborhood.magnitude < 1.5f)
        {
            theAgent.TransitionToState(theAgent.AttackState);
        }
        theAgent.NavMeshAgent.SetDestination(theAgent.patrolPos);
    }
}
