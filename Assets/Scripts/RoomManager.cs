using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ActivationConsole activationConsole;
    [SerializeField] private ProgressDoor[] progressDoors;

    private bool roomCompleted;

    public bool IsCompleted => roomCompleted;

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
