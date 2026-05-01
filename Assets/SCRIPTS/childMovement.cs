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


    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerCloseInRange = Physics.CheckSphere(transform.position, closeRange, whatIsPlayer);

        if (!playerInSightRange && !playerCloseInRange) Patroling();
        if(playerInSightRange && !playerCloseInRange) ChasePlayer();
        if(playerInSightRange && playerCloseInRange) WatchingPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
    }

    private void ChasePlayer()
    {
        
    }

    private void WatchingPlayer()
    {

    }
}
