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
        // The player can only carry one item at a time.
        if (HasItem)
            return;

        if (other.TryGetComponent(out ObjectiveItem item))
        {
            pickupSound.Play();
            item.AttachTo(carryPoint);
            carriedItem = item;
        }
    }

    public ObjectiveItem DepositItem()
    {
        if (!HasItem)
            return null;

        ObjectiveItem itemToDeposit = carriedItem;
        itemToDeposit.Release();
        carriedItem = null;

        return itemToDeposit;
    }
}