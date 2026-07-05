using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [SerializeField]
    private ObjectiveItemType itemType;
    [SerializeField] private Transform carryPoint;

    private ObjectiveItem carriedItem;

    public bool HasItem => carriedItem != null;

    private void OnTriggerEnter(Collider other)
    {
        if (HasItem)
            return;

        if (other.TryGetComponent(out ObjectiveItem item))
        {
            item.AttachTo(carryPoint);
            carriedItem = item;
        }

        /*
        // OPTION B (Press E to Pick Up)

        if (other.TryGetComponent(out CarryableItem item))
        {
            nearbyItem = item;
        }
        */
    }

    /*
    // OPTION B

    private CarryableItem nearbyItem;

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame &&
            nearbyItem != null && !HasItem)
        {
            nearbyItem.Collect(carryPoint);
            carriedItem = nearbyItem;
            nearbyItem = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CarryableItem item) &&
            item == nearbyItem)
        {
            nearbyItem = null;
        }
    }
    */

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