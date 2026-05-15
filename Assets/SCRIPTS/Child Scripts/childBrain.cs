using UnityEngine;

public class childBrain : MonoBehaviour
{
    public enum ChildState
    {
        Chasing,
        Watching,
        Idle,
        Scared,
        Drawing,
        Hiding
    }

    public ChildState state;

    public bool stateLocked;
}
