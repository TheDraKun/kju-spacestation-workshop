using UnityEngine;

public class EscapeConsole : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] private Renderer[] statusRenderers;
    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private Material readyMaterial;
    [SerializeField] private Material activeMaterial;

    [Header("References")]
    [SerializeField] private EscapePod escapePod;
    [SerializeField] private AudioSource activationSound;

    private bool isReady;
    private bool isActivated;

    public bool IsReady => isReady;
    public bool IsActivated => isActivated;

    private void Start()
    {
        SetInactiveStatus();
    }

    public void SetReady()
    {
        if (isReady)
            return;

        isReady = true;

        SetReadyStatus();

        Debug.Log("Escape Console Ready!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isReady)
            return;

        if (isActivated)
            return;

        if (!other.TryGetComponent<PlayerCarry>(out _))
            return;

        Activate();
    }

    private void Activate()
    {
        activationSound.Play();

        isActivated = true;

        SetActivatedStatus();

        escapePod.Arrive();
        GameManager.Instance.OnEscapeActivated();

        Debug.Log("Escape Sequence Initiated!");
    }

    private void SetInactiveStatus()
    {
        foreach (Renderer renderer in statusRenderers)
        {
            renderer.material = inactiveMaterial;
        }
    }

    private void SetReadyStatus()
    {
        foreach (Renderer renderer in statusRenderers)
        {
            renderer.material = readyMaterial;
        }
    }

    private void SetActivatedStatus()
    {
        foreach (Renderer renderer in statusRenderers)
        {
            renderer.material = activeMaterial;
        }
    }
}