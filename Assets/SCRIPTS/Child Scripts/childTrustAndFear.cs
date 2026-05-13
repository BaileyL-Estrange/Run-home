using UnityEngine;

public class childTrustAndFear : MonoBehaviour
{
    public enum ChildEmotions
    {
        Stranger,
        LowTrust,
        MidTrust,
        HighTrust,
        Fear,
        Sad,
        Happy
    }

    public ChildEmotions state;

    public bool stateLocked;
}
