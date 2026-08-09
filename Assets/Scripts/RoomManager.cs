using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DepositStation depositStation;
    [SerializeField] private ActivationConsole activationConsole;

    [SerializeField] private ProgressDoor[] progressDoors;
    [SerializeField] private ObjectiveItemSpawner itemSpawner;

    private bool roomCompleted;

    public int CurrentItems => depositStation.CurrentItems;
    public int RequiredItems => depositStation.RequiredItems;
    public bool IsCompleted => roomCompleted;

    public void InitializeRoom()
    {
        itemSpawner.SpawnItems();
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

        GameManager.Instance.OnRoomCompleted(this);
        Debug.Log($"{gameObject.name} Completed!");
    }
}
