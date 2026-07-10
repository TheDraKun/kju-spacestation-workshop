using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Rooms")]
    [SerializeField] private RoomManager[] initialRooms;
    [SerializeField] private RoomManager finalRoom;

    [Header("Final Sequence")]
    [SerializeField] private EscapeConsole escapeConsole;

    [Header("UI Manager")]
    [SerializeField] private UIManager uiManager;

    private bool controlRoomUnlocked;
    private bool escapeConsoleEnabled;

    private RoomManager reactorRoom => initialRooms[0];
    private RoomManager medbayRoom => initialRooms[1];

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

        InitializeUI();
    }
    private void InitializeUI()
    {
        uiManager.ShowReactor();
        uiManager.ShowMedbay();

        uiManager.HideControlRoom();
        uiManager.HideEscape();

        uiManager.SetReactorActive();
        uiManager.SetMedbayActive();

        uiManager.UpdateReactorProgress(0, reactorRoom.RequiredItems);
        uiManager.UpdateMedbayProgress(0, medbayRoom.RequiredItems);

        uiManager.ShowPopup(
            "MISSION START",
            "Restore the Reactor and Medbay to Unlock the Control Room");
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

    private void UnlockEscapeConsole()
    {
        escapeConsole.SetReady();

        uiManager.ShowEscape();
        uiManager.SetEscapeActive();

    }

    internal void CompleteGame()
    {
        Invoke(nameof(InvokeCompleteGame), 2f);
    }
    private void InvokeCompleteGame()
    {
        uiManager.ShowStageCompletion();
    }

    public void UpdateRoomProgress(ObjectiveItemType itemType)
    {
        switch (itemType)
        {
            case ObjectiveItemType.EnergyCore:
                uiManager.UpdateReactorProgress(
                    reactorRoom.CurrentItems,
                    reactorRoom.RequiredItems);
                break;
            case ObjectiveItemType.MedPack:
                uiManager.UpdateMedbayProgress(
                    medbayRoom.CurrentItems,
                    medbayRoom.RequiredItems);
                break;
            case ObjectiveItemType.DataChip:
                uiManager.UpdateControlRoomProgress(
                    finalRoom.CurrentItems,
                    finalRoom.RequiredItems);
                break;
        }
    }
    public void OnEscapeActivated()
    {
        uiManager.SetEscapeComplete();

        uiManager.ShowPopup(
            "ESCAPE INITIATED",
            "Escape Pod Incoming...");
    }
    internal void OnRoomCompleted(RoomManager roomManager)
    {
        //Check if All rooms are completed to Unlock the Control Room
        if (AreInitialRoomsCompleted() && !controlRoomUnlocked)
        {
            controlRoomUnlocked = true;

            finalRoom.InitializeRoom();

            uiManager.ShowControlRoom();
            uiManager.SetControlRoomActive();
            uiManager.UpdateControlRoomProgress(0, finalRoom.RequiredItems);
        }

        if (roomManager == reactorRoom)
        {
            uiManager.ShowPopup(
            "REACTOR RESTORED",
            "Power Systems Online");
            uiManager.SetReactorComplete();
        }
        else if (roomManager == medbayRoom)
        {
            uiManager.ShowPopup(
                "MEDBAY RESTORED",
                "Medical Systems Online");
            uiManager.SetMedbayComplete();
        }
        else if (roomManager == finalRoom)
        {
            UnlockEscapeConsole();
            uiManager.SetControlRoomComplete();

            uiManager.ShowPopup(
                "CONTROL ROOM RESTORED",
                "Escape Console Online");

        }
    }
}