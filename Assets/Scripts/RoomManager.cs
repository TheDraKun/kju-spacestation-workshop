using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ActivationConsole activationConsole;
    [SerializeField] private ProgressDoor[] progressDoors;
    [SerializeField] private ObjectiveItemSpawner itemSpawner;

    private bool roomCompleted;

    public bool IsCompleted => roomCompleted;

    private void Start()
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

        Debug.Log($"{gameObject.name} Completed!");
    }
}
