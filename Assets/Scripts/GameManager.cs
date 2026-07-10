using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] private RoomManager[] initialRooms;
    [SerializeField] private RoomManager finalRoom;

    [Header("Final Sequence")]
    [SerializeField] private EscapeConsole escapeConsole;

    private bool controlRoomUnlocked;
    private bool escapeConsoleEnabled;

    private void Start()
    {
        foreach (var room in initialRooms)
        {
            room.InitializeRoom();
        }
    }

    private void Update()
    {
        CheckControlRoomUnlock();
        CheckEscapeConsoleUnlock();
    }

    private void CheckControlRoomUnlock()
    {
        if (controlRoomUnlocked)
            return;

        foreach (var room in initialRooms)
        {
            if (!room.IsCompleted)
                return;
        }

        controlRoomUnlocked = true;

        finalRoom.InitializeRoom();

        Debug.Log("Control Room Unlocked!");
    }

    private void CheckEscapeConsoleUnlock()
    {
        if (escapeConsoleEnabled)
            return;

        if (!finalRoom.IsCompleted)
            return;

        escapeConsoleEnabled = true;

        escapeConsole.SetReady();

        Debug.Log("Escape Console Ready!");
    }
}