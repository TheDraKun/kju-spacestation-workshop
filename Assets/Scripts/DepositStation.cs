using System.Collections.Generic;
using UnityEngine;

public class DepositStation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ObjectiveItemType requiredItemType;
    [SerializeField] private int requiredItems = 3;

    [Header("Debug")]
    [SerializeField] private int currentItems;

    [SerializeField] private List<Transform> depositSockets;

    [SerializeField] private Renderer[] statusRenderers;

    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private Material activeMaterial;

    public int RequiredItems => requiredItems;
    public int CurrentItems => currentItems;
    public bool IsComplete => currentItems >= requiredItems;

    public void Initialize(int count)
    {
        requiredItems = count;
    }
    private void Start()
    {
        SetStatus(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsComplete)
            return;

        if (!other.TryGetComponent(out PlayerCarry playerCarry))
            return;

        if (!playerCarry.HasItem)
            return;

        if (playerCarry.CarriedItem.ItemType != requiredItemType)
            return;

        Deposit(playerCarry.DepositItem());
    }

    private void Deposit(ObjectiveItem item)
    {
        if (currentItems >= requiredItems)
            return;

        if (currentItems >= depositSockets.Count)
        {
            Debug.LogError("Not enough deposit sockets configured.");
            return;
        }

        Debug.Log($"Deposited Item: {item.name}");

        item.AttachTo(depositSockets[currentItems]);

        currentItems++;

        Debug.Log($"Deposit Progress : {currentItems}/{requiredItems}");

        if (IsComplete)
        {
            OnDepositCompleted();
        }
    }

    private void OnDepositCompleted()
    {
        SetStatus(true);

        Debug.Log("Deposit Station Complete!");
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

    public void ResetStation()
    {
        currentItems = 0;
        SetStatus(false);
    }
}