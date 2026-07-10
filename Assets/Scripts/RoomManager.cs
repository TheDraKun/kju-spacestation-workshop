using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private int requiredItems = 3;
    [SerializeField] private DepositStation depositStation;
    [SerializeField] private ActivationConsole activationConsole;

    [SerializeField] private ProgressDoor[] progressDoors;
    [SerializeField] private ObjectiveItemSpawner itemSpawner;

    private bool roomCompleted;
    public bool IsCompleted => roomCompleted;
    public int RequiredItems => requiredItems;
    public int CurrentItems => depositStation.CurrentItems;
    private void Start()
    {
        depositStation.Initialize(requiredItems);
        itemSpawner.SetSpawnCount(requiredItems);
    }
    private void Update()
    {
        if (roomCompleted)
            return;

        if (!depositStation.IsComplete)
            return;

        if (depositStation.IsComplete && !activationConsole.IsReady)
        {
            activationConsole.SetAsReady();
        }

        if (!activationConsole.IsActivated)
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

        OnRoomCompleted();
        Debug.Log($"{gameObject.name} Completed!");
    }

    public void InitializeRoom()
    {
        depositStation.ResetStation();
        activationConsole.ResetConsole();
        itemSpawner.SpawnItems();
        roomCompleted = false;
    }

    private void OnRoomCompleted()
    {
        GameManager.Instance.OnRoomCompleted(this);
    }
}