using System.Collections.Generic;
using UnityEngine;

public class DepositStation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ObjectiveItemType requiredItemType;
    [SerializeField] private int requiredItems = 3;

    [Header("References")]
    [SerializeField] private List<Transform> depositSockets;
    [SerializeField] private Renderer[] statusRenderers;
    [SerializeField] private RoomManager roomManager;

    [Header("Materials")]
    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private Material activeMaterial;

    [Header("Audio")]
    [SerializeField] private AudioSource depositSound;

    [Header("Debug")]
    [SerializeField] private int currentItems;

    public int RequiredItems => requiredItems;
    public int CurrentItems => currentItems;
    public bool IsComplete => currentItems >= requiredItems;

    private void Start()
    {
        SetStatus(false);
    }

    public void Initialize(int count)
    {
        requiredItems = count;
    }

    public void ResetStation()
    {
        currentItems = 0;
        SetStatus(false);
    }

    private void Deposit(ObjectiveItem item)
    {
        if (IsComplete)
            return;

        if (currentItems >= depositSockets.Count)
        {
            Debug.LogError("Not enough deposit sockets configured.");
            return;
        }

        depositSound.Play();

        Transform socket = depositSockets[currentItems];
        item.AttachTo(socket);

        currentItems++;

        Debug.Log($"Deposit Progress : {currentItems}/{requiredItems}");
        GameManager.Instance.UpdateRoomProgress(requiredItemType);

        if (IsComplete)
        {
            OnDepositCompleted();
        }
    }

    private void OnDepositCompleted()
    {
        SetStatus(true);
        roomManager.OnDepositCompleted();

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
}
