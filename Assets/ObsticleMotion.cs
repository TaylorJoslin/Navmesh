using UnityEngine;
using UnityEngine.AI;

public class RepeatingFollowPath : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] points;
    private NavMeshAgent agent;
    private int pointIndex;

    void Start()
    {
        pointIndex = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(points[pointIndex].position);
    }

    void Update()
    {
        agent.speed = Random.Range(3,10);

        // Check if AI has reached current waypoint
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            // Move to next waypoint
            pointIndex = (pointIndex + 1) % points.Length;
            agent.SetDestination(points[pointIndex].position);
        }
    }
}