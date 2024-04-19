using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public GameObject myCube;

    public Vector3 safePos;
    public Vector3 fightPos;
    public Vector3 patrolPos;

    private MeshRenderer meshRenderer;
    private NavMeshAgent myAgent;

    public MeshRenderer MeshRenderer{ get { return meshRenderer; }}

    public NavMeshAgent NavMeshAgent { get { return myAgent; } }

    private BaseState currentState;

    public BaseState CurrentState { get { return currentState; } }

    public readonly AttackState AttackState = new AttackState();
    public readonly PatrolState PatrolState = new PatrolState();
    public readonly RetreatState RetreatState = new RetreatState();

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        myAgent = GetComponent<NavMeshAgent>();
        safePos = new Vector3(2, 0, 2);
        fightPos = new Vector3(-2, 0, -2);
        patrolPos = new Vector3(2,0,-2);
    }

    private void Start()
    {
        TransitionToState(PatrolState);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollistionEnter(this);

    }

    public void TransitionToState(BaseState state)
    {
        currentState = state;
       currentState.EnterState(this);
    }
}
