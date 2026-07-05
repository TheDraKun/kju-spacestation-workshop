using UnityEngine;

public class ActivationConsole : MonoBehaviour
{
    [SerializeField] private DepositStation depositStation;

    [SerializeField] private Renderer[] statusRenderers;

    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private Material readyMaterial;
    [SerializeField] private Material activeMaterial;

    private bool isReady;
    private bool isActivated;

    public bool IsActivated => isActivated;
    public bool IsReady => isReady;
    private void Start()
    {
        SetStatus(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated)
            return;

        if (!depositStation.IsComplete)
            return;

        if (!other.TryGetComponent<PlayerCarry>(out _))
            return;

        Activate();
    }

    private void Activate()
    {
        isActivated = true;
        Debug.Log("Console Activated!");
        SetStatus(true);
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
    public void SetAsReady()
    {
        isReady = true;
        Debug.Log("Console is Ready!");
        foreach (var renderer in statusRenderers)
        {
            renderer.material = readyMaterial;
        }
    }
}