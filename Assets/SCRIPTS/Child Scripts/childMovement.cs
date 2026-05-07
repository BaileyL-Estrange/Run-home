using UnityEngine;
using UnityEngine.AI;

public class childMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //wandering around
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange, closeRange;
    public bool playerInSightRange, playerCloseInRange;

    //State system

    private childBrain brain;


    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
        brain = GetComponent<childBrain>();
        brain.stateLocked = false;
    }

    private void Update() 
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerCloseInRange = Physics.CheckSphere(transform.position, closeRange, whatIsPlayer);

        if (!brain.stateLocked)
        {
            if (!playerInSightRange && !playerCloseInRange)
                brain.state = childBrain.ChildState.Patrolling;

            if (playerInSightRange && !playerCloseInRange)
                brain.state = childBrain.ChildState.Chasing;

            if (playerInSightRange && playerCloseInRange)
                brain.state = childBrain.ChildState.Watching;

        }

        switch(brain.state)
        {
            case childBrain.ChildState.Patrolling:
                Patroling();
                break;
            case childBrain.ChildState.Chasing:
                ChasePlayer();
                break;
            case childBrain.ChildState.Watching:
                WatchingPlayer();
                break;
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //When reached walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void WatchingPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);
    }
}
