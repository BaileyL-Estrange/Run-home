using UnityEngine;

public class childTrustAndFear : MonoBehaviour
{
    public enum ChildTrust
    {
        Stranger,
        LowTrust,
        MidTrust,
        HighTrust,
        Fear
    }

    public ChildTrust state;

    public bool stateLocked;
}
