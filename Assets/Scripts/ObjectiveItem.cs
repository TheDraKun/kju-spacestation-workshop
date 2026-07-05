using UnityEngine;

public enum ObjectiveItemType
{
    EnergyCore
}

public class ObjectiveItem : MonoBehaviour
{
    public void AttachTo(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        if (TryGetComponent(out Collider itemCollider))
            itemCollider.enabled = false;
    }

    public void Detach()
    {
        transform.SetParent(null);
    }
}