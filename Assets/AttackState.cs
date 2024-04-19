using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState(AgentController theAgent)
    {
        Debug.Log("attack");
        theAgent.MeshRenderer.material.color = Color.red;
    }

    public override void OnCollistionEnter(AgentController theAgent)
    {

    }

    public override void Update(AgentController theAgent)
    {
        Vector3 neighborhood = theAgent.transform.position - theAgent.fightPos;
        //Debug.Log(neighborhood.magnitude);
        if (neighborhood.magnitude < 1.5f)
        {
            theAgent.TransitionToState(theAgent.RetreatState);
        }
        theAgent.NavMeshAgent.SetDestination(theAgent.fightPos);
    }
}
