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
        hiddenPosition = transform.localPosition;
    }

    public void Arrive()
    {
        MoveTo(raisedPosition);
    }

    public void Escape()
    {
        MoveTo(hiddenPosition);

        Debug.Log("Game Complete!");
        GameManager.Instance.ShowGameCompleteScreen();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayerBoarded)
            return;

        if (!other.TryGetComponent<PlayerMovement>(out _))
            return;

        other.gameObject.SetActive(false);
        hasPlayerBoarded = true;
        Escape();
    }
}
