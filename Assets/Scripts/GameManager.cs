using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Rooms")]
    [SerializeField] private RoomManager[] initialRooms;
    [SerializeField] private RoomManager finalRoom;

    [SerializeField] private EscapeConsole escapeConsole;

    [Header("UI Manager")]
    [SerializeField] private UIManager uiManager;

    private bool controlRoomUnlocked;

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
        uiManager.ShowReactorObjective();
        uiManager.ShowMedbayObjective();

        uiManager.HideControlRoomObjective();
        uiManager.HideEscape();

        uiManager.SetReactorObjectiveActive();
        uiManager.SetMedbayObjectiveActive();

        UpdateRoomProgress(ObjectiveItemType.EnergyCore);
        UpdateRoomProgress(ObjectiveItemType.MedPack);
        UpdateRoomProgress(ObjectiveItemType.DataChip);

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
    internal void OnRoomCompleted(RoomManager roomManager)
    {
        if (roomManager == reactorRoom)
        {
            uiManager.SetReactorObjectiveComplete();
            uiManager.ShowPopup(
                "REACTOR RESTORED",
                "Power Systems Online");
        }
        else if (roomManager == medbayRoom)
        {
            uiManager.SetMedbayObjectiveComplete();
            uiManager.ShowPopup(
                "MEDBAY RESTORED",
                "Medical Systems Online");
        }
        else if (roomManager == finalRoom)
        {
            uiManager.SetControlRoomObjectiveComplete();
            uiManager.ShowPopup(
                "CONTROL ROOM RESTORED",
                "Escape Console Online");

            UnlockEscapeConsole();
            return;
        }

        if (controlRoomUnlocked)
            return;

        if (!AreInitialRoomsCompleted())
            return;

        controlRoomUnlocked = true;

        finalRoom.InitializeRoom();

        uiManager.ShowControlRoomObjective();
        uiManager.SetControlRoomObjectiveActive();
    }

    private void UnlockEscapeConsole()
    {
        escapeConsole.SetReady();

        uiManager.SetControlRoomObjectiveComplete();

        uiManager.ShowPopup(
            "CONTROL ROOM RESTORED",
            "Escape Console Online");
    }

    public void OnEscapeActivated()
    {
        uiManager.SetEscapeObjectiveComplete();

        uiManager.ShowPopup(
            "ESCAPE INITIATED",
            "Escape Pod Incoming...");
    }

    internal void ShowGameCompleteScreen()
    {
        uiManager.ShowStageCompletion();
    }
}
