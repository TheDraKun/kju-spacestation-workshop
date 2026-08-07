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
        // TODO: Start the console in its inactive visual state.
    }

    public void SetReady()
    {
        // TODO: Mark the console as ready and update its visuals.
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Only activate when the console is ready.
        // TODO: Prevent the console from activating more than once.
        // TODO: Check that the Player entered the trigger.
        // TODO: Activate the escape sequence.
    }

    private void Activate()
    {
        // TODO: Play the activation sound.
        // TODO: Mark the console as activated.
        // TODO: Update the console visuals.
        // TODO: Make the Escape Pod arrive.
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
