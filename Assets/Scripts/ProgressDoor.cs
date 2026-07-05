using UnityEngine;

public class ProgressDoor : MonoBehaviour
{
    [SerializeField] private Collider doorCollider;

    private bool isOpen;
    public bool IsOpen => isOpen;

    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;

        doorCollider.enabled = false;

        Debug.Log("Door Opened!");
    }

    public void Close()
    {
        if (!isOpen)
            return;

        isOpen = false;

        doorCollider.enabled = true;

        Debug.Log("Door Closed!");
    }
}