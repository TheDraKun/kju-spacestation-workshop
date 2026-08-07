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
        // TODO: Stop if the station is already complete.

        // TODO: Make sure there is a free deposit socket.

        // TODO: Play the deposit sound.

        // TODO: Attach the deposited item to the next socket.

        // TODO: Increase the deposited item count.

        // TODO: When enough items have been deposited, complete the station.
    }

    private void OnDepositCompleted()
    {
        // TODO: Change the station to its active visual state.

        // TODO: Tell the RoomManager that this deposit station is complete.
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
        // TODO: Ignore interaction if this station is already complete.

        // TODO: Check whether the object entering is the Player with PlayerCarry.

        // TODO: Make sure the Player is carrying an item.

        // TODO: Make sure the carried item is the type this station requires.

        // TODO: Remove the item from the Player and deposit it.
    }
}
