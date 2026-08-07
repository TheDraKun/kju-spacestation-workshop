using System.Collections;
using UnityEngine;

public class ProgressDoor : MonoBehaviour
{
    [SerializeField] private Collider doorCollider;

    [Header("Animation")]
    [SerializeField] private float openDistance = 3f;
    [SerializeField] private float openDuration = 1f;

    private Vector3 closedPosition;
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

        StartCoroutine(AnimateDoor(closedPosition + Vector3.right * openDistance));

        Debug.Log("Door Opened!");
    }

    private IEnumerator AnimateDoor(Vector3 targetPosition)
    {
        Vector3 startPosition = doorCollider.transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < openDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / openDuration);
            doorCollider.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        doorCollider.transform.localPosition = targetPosition;
    }
}
