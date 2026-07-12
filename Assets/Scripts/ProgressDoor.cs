using UnityEngine;

public class ProgressDoor : MonoBehaviour
{
    [SerializeField] private Collider doorCollider;

    [Header("Animation")]
    [SerializeField] private float openDistance = 3f;
    [SerializeField] private float openDuration = 1f;

    private Vector3 closedPosition;
    private Coroutine animationRoutine;

    private bool isOpen;
    public bool IsOpen => isOpen;

    private void Awake()
    {
        closedPosition = doorCollider.transform.localPosition;
    }

    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;

        doorCollider.enabled = false;

        doorCollider.transform.localPosition = closedPosition + Vector3.right * openDistance;

        Debug.Log("Door Opened!");
    }
}