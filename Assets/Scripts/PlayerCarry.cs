using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform carryPoint;

    [Header("Audio")]
    [SerializeField] private AudioSource pickupSound;

    private ObjectiveItem carriedItem;

    public bool HasItem => carriedItem != null;
    public ObjectiveItem CarriedItem => carriedItem;

    private void OnTriggerEnter(Collider other)
    {
        // The Player can only carry one objective item at a time.

        // Check whether the object we touched is an ObjectiveItem.

        // Play the pickup sound.

        // Attach the item to the carry point and remember it.
    }

    public ObjectiveItem DepositItem()
    {
        // If we are not carrying anything, there is nothing to deposit.

        // Store the carried item before clearing our reference.

        // Release the item from the Player.

        // Clear the carried item reference.

        // Return the deposited item to the system that requested it.
        return null;
    }
}
