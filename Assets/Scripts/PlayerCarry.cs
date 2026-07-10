using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [SerializeField] private Transform carryPoint;
    [SerializeField] private AudioSource pickupSound;

    private ObjectiveItem carriedItem;

    public bool HasItem => carriedItem != null;
    public ObjectiveItem CarriedItem => carriedItem;

    private void OnTriggerEnter(Collider other)
    {
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
        itemToDeposit.Detach();
        carriedItem = null;

        return itemToDeposit;
    }
}