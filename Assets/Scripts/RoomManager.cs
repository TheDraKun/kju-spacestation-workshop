using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int requiredItems = 3;

    [Header("References")]
    [SerializeField] private DepositStation depositStation;
    [SerializeField] private ActivationConsole activationConsole;
    [SerializeField] private ObjectiveItemSpawner itemSpawner;
    [SerializeField] private ProgressDoor[] progressDoors;

    private bool roomCompleted;

    public bool IsCompleted => roomCompleted;
    public int RequiredItems => requiredItems;
    public int CurrentItems => depositStation.CurrentItems;

    private void Start()
    {
        depositStation.Initialize(requiredItems);
        itemSpawner.SetSpawnCount(requiredItems);
    }

    public void OnDepositCompleted()
    {
        activationConsole.SetAsReady();
    }

    public void OnConsoleActivated()
    {
        if (roomCompleted)
            return;

        CompleteRoom();
    }

    private void CompleteRoom()
    {
        roomCompleted = true;

        foreach (var door in progressDoors)
        {
            door.Open();
        }

        Debug.Log($"{gameObject.name} Completed!");

        GameManager.Instance.OnRoomCompleted(this);
    }

    public void InitializeRoom()
    {
        roomCompleted = false;

        depositStation.ResetStation();
        activationConsole.ResetConsole();
        itemSpawner.SpawnItems();
    }
}