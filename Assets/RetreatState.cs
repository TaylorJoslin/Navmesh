using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    public override void EnterState(AgentController theAgent)
    {
        Debug.Log("Patrol");
        theAgent.MeshRenderer.material.color = Color.yellow;
    }

    public override void OnCollistionEnter(AgentController theAgent)
    {

    }

    public override void Update(AgentController theAgent)
    {
        Vector3 neighborhood = theAgent.transform.position - theAgent.safePos;
        //Debug.Log(neighborhood.magnitude);
        if (neighborhood.magnitude < 1.5f)
        {
            theAgent.TransitionToState(theAgent.PatrolState);
        }
        theAgent.NavMeshAgent.SetDestination(theAgent.safePos);
    }
}
