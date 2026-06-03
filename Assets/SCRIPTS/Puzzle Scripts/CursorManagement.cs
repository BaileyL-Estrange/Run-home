using UnityEngine;

public class CursorManagement : MonoBehaviour
{
    public static bool inUI;

    public static void SetUI(bool state)
    {
        inUI = state;

        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
