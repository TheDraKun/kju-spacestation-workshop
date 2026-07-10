using System.Collections;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Vector3 raisedPosition;
    [SerializeField] private float moveDuration = 2f;

    private Vector3 hiddenPosition;
    private Coroutine movementRoutine;

    private bool hasPodUtilize = false;

    private void Awake()
    {
        hiddenPosition = transform.localPosition;
        hasPodUtilize = false;
    }

    public void Arrive()
    {
        MoveTo(raisedPosition);
    }

    public void Depart()
    {
        MoveTo(hiddenPosition);
    }

    private void MoveTo(Vector3 targetPosition)
    {
        if (movementRoutine != null)
            StopCoroutine(movementRoutine);

        movementRoutine = StartCoroutine(MoveRoutine(targetPosition));
    }

    private IEnumerator MoveRoutine(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / moveDuration);

            transform.localPosition = Vector3.Lerp(
                startPosition,
                targetPosition,
                t);

            yield return null;
        }

        transform.localPosition = targetPosition;

        movementRoutine = null;

        Debug.Log($"Escape Pod moved to {targetPosition}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasPodUtilize)
            return;
        if (other.TryGetComponent(out PlayerMovement _))
        {
            other.gameObject.SetActive(false);

            hasPodUtilize = true;

            Depart();

            Debug.Log("Player Entered Escape Pod!");

            // TODO:
            // GameManager.Instance.CompleteGame();
        }
    }
}