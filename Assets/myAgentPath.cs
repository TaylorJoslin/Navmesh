using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class myAgentPath : MonoBehaviour
{
    //[SerializeField] Vector3 mouse;
    [SerializeField] Transform mouse;


    //[SerializeField] float catDetectionRadius = 5f; // Radius to detect cat
    [SerializeField] float randomMovementDuration = 3f;


    NavMeshAgent myAgent;

    public bool isRandomMoving = false;
    float randomMoveTimer = 1f;
    Vector3 randomDestination;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = Random.Range(5, 10);
    }

    void Update()
    {
        Vector3 mousePos = mouse.transform.position;

        if (!isRandomMoving)
        {
            // If not moving randomly, set destination to mouse position
            myAgent.SetDestination(mousePos);
        }
        else
        {
            // If moving randomly, set random speed
            myAgent.speed = Random.Range(5, 10);

            // Move randomly for a few seconds
            if (randomMoveTimer > 0)
            {
                myAgent.SetDestination(randomDestination);
                randomMoveTimer -= Time.deltaTime;
            }
            else
            {
                isRandomMoving = false;
            }
        }

        //myAgent.SetDestination(mousePos);

        //if (isRandomMoving)
        //{
        //    // Move randomly for a few seconds
        //    if (randomMoveTimer > 0)
        //    {
        //        myAgent.SetDestination(randomDestination);
        //        randomMoveTimer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        isRandomMoving = false;

        //    }
        //}
        //else
        //{
        //    // Continue chasing the mouse
        //    myAgent.SetDestination(mousePos);
        //    myAgent.speed = Random.Range(5, 10);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            // Start random movement
            isRandomMoving = true;
            randomMoveTimer = randomMovementDuration;
            randomDestination = GetRandomPointInNavMesh();

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Yarn")
        {
            GameManager.instance.AddPoints(1);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Mouse")
        {
            GameManager.instance.LoseCondition();
        }
    }

    Vector3 GetRandomPointInNavMesh()
    {
        NavMeshHit hit;
        Vector3 randomDestination = transform.position;
        if (NavMesh.SamplePosition(Random.insideUnitSphere * 10f + transform.position, out hit, 10f, NavMesh.AllAreas))
        {
            randomDestination = hit.position;
        }
        return randomDestination;
    }

    void OnDrawGizmosSelected()
    {
        // Draw detection radius for the cat
        Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, catDetectionRadius);
    }

}
