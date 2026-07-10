using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [SerializeField] private Transform carryPoint;

    private ObjectiveItem carriedItem;

    public bool HasItem => carriedItem != null;
    public ObjectiveItem CarriedItem => carriedItem;

    private void OnTriggerEnter(Collider other)
    {
        if (HasItem)
            return;

        if (other.TryGetComponent(out ObjectiveItem item))
        {
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