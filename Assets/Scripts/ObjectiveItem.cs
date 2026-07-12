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
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        if (TryGetComponent(out Collider itemCollider))
            itemCollider.enabled = false;
    }

    public void Release()
    {
        transform.SetParent(null);
    }
}