using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class myAgentPath : MonoBehaviour
{
    //[SerializeField] Vector3 mouse;
    [SerializeField] Transform mouse;

    
    NavMeshAgent myAgent;
    void Start()
    {
       
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 mousePos = mouse.transform.position;

        myAgent.speed = Random.Range(3, 10);

        myAgent.SetDestination(mousePos);
    }
}
