using UnityEngine;
using UnityEngine.AI;

public class childMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

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
                brain.state = childBrain.ChildState.Idle;

            if (playerInSightRange && !playerCloseInRange)
                brain.state = childBrain.ChildState.Chasing;

            if (playerInSightRange && playerCloseInRange)
                brain.state = childBrain.ChildState.Watching;

        }

        switch(brain.state)
        {
            case childBrain.ChildState.Idle:
                Idle();
                break;
            case childBrain.ChildState.Chasing:
                ChasePlayer();
                break;
            case childBrain.ChildState.Watching:
                WatchingPlayer();
                break;
        }
    }

    private void Idle()
    {
        
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
