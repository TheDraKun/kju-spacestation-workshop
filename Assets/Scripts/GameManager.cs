using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Rooms")]
    [SerializeField] private RoomManager[] initialRooms;
    [SerializeField] private RoomManager finalRoom;

    [SerializeField] private EscapeConsole escapeConsole;

    private bool controlRoomUnlocked;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        foreach (RoomManager room in initialRooms)
        {
            room.InitializeRoom();
        }
    }

    private bool AreInitialRoomsCompleted()
    {
        foreach (RoomManager room in initialRooms)
        {
            if (!room.IsCompleted)
                return false;
        }

        return true;
    }

    internal void OnRoomCompleted(RoomManager roomManager)
    {
        if (roomManager == finalRoom)
        {
            escapeConsole.SetReady();
            return;
        }

        if (controlRoomUnlocked)
            return;

        if (!AreInitialRoomsCompleted())
            return;

        controlRoomUnlocked = true;
        finalRoom.InitializeRoom();
    }

    private void UnlockEscapeConsole()
    {
        escapeConsole.SetReady();

    }
}
