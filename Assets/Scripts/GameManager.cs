using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Rooms")]
    [SerializeField] private RoomManager[] initialRooms;
    [SerializeField] private RoomManager finalRoom;

    private bool controlRoomUnlocked;

    private void Awake()
    {
        // TODO: Create the GameManager singleton.
        // If another GameManager already exists, destroy this one.
    }

    private void Start()
    {
        // TODO: Initialize the starting rooms.
        // The Control Room should remain inactive until the initial rooms are complete.
    }

    private bool AreInitialRoomsCompleted()
    {
        // TODO: Check every room in initialRooms.
        // Return false if any room is not completed.

        return false;
    }

    internal void OnRoomCompleted(RoomManager roomManager)
    {
        // TODO: Check whether Reactor and MedBay are both complete.
        // TODO: Make sure the Control Room is only unlocked once.
        // TODO: Initialize finalRoom when the requirements are met.
    }
}
