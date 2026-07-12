using UnityEngine;

public class ActivationConsole : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DepositStation depositStation;
    [SerializeField] private RoomManager roomManager;

    [Header("Visuals")]
    [SerializeField] private Renderer[] statusRenderers;
    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private Material readyMaterial;
    [SerializeField] private Material activeMaterial;

    [Header("Audio")]
    [SerializeField] private AudioSource activationSound;
    private bool isReady;
    private bool isActivated;

    public bool IsReady => isReady;
    public bool IsActivated => isActivated;

    private void Start()
    {
        SetStatus(false);
    }
    public void ResetConsole()
    {
        isActivated = false;
        isReady = false;
        SetStatus(false);
    }

    private void Activate()
    {
        isActivated = true;

        activationSound.Play();
        SetStatus(true);
        roomManager.OnConsoleActivated();
        Debug.Log("Console Activated!");
    }
    public void SetAsReady()
    {
        isReady = true;
        Debug.Log("Console is Ready!");
        foreach (var renderer in statusRenderers)
        {
            renderer.material = readyMaterial;
        }
    }

    private void SetStatus(bool active)
    {
        foreach (var renderer in statusRenderers)
        {
            renderer.material = active
                ? activeMaterial
                : inactiveMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (IsActivated)
            return;

        if (!depositStation.IsComplete)
            return;

        if (!other.TryGetComponent<PlayerCarry>(out _))
            return;

        Activate();
    }
}