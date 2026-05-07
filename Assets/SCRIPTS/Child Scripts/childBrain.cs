using UnityEngine;

public class childBrain : MonoBehaviour
{
    public enum ChildState
    {
        Patrolling,
        Chasing,
        Watching,
        Idle
    }

    public ChildState state;

    public bool stateLocked;
}
