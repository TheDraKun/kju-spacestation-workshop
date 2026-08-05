using UnityEngine;

[System.Serializable]
public enum ObjectiveItemType
{
    None = 0,
    EnergyCore = 1,
    MedPack = 2,
    DataChip = 3
}

public class ObjectiveItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ObjectiveItemType itemType;

    public ObjectiveItemType ItemType => itemType;

    public void AttachTo(Transform parent)
    {
        // Parent this objective item to the Player's carry point.

        // Reset its local position and rotation so it sits correctly.

        // Disable its Collider while it is being carried.
    }

    public void Release()
    {
        // Remove this item from its current parent.
    }
}
