using System.Collections;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Vector3 raisedPosition;
    [SerializeField] private float moveDuration = 2f;

    private Vector3 hiddenPosition;
    private Coroutine movementRoutine;
    private bool hasPlayerBoarded;

    private void Awake()
    {
        // TODO: Remember the Escape Pod's starting hidden position.
    }

    public void Arrive()
    {
        // TODO: Move the Escape Pod to its raised position.
    }

    public void Escape()
    {
        // TODO: Move the Escape Pod back to its hidden position.
    }

    private void MoveTo(Vector3 targetPosition)
    {
        // TODO: Stop the current movement routine if one is already running.
        // TODO: Start moving toward targetPosition.
    }

    private IEnumerator MoveRoutine(Vector3 targetPosition)
    {
        // TODO: Smoothly move from the current position to targetPosition.
        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Prevent boarding more than once.
        // TODO: Check that the Player entered the pod.
        // TODO: Hide the Player and start the escape.
    }
}
