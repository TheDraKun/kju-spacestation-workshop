using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Reactor")]
    [SerializeField] private GameObject reactorGroup;
    [SerializeField] private TMP_Text reactorProgressText;
    [SerializeField] private Image reactorStatusImage;

    [Header("Medbay")]
    [SerializeField] private GameObject medbayGroup;
    [SerializeField] private TMP_Text medbayProgressText;
    [SerializeField] private Image medbayStatusImage;

    [Header("Control Room")]
    [SerializeField] private GameObject controlRoomGroup;
    [SerializeField] private TMP_Text controlRoomProgressText;
    [SerializeField] private Image controlRoomStatusImage;

    [Header("Escape")]
    [SerializeField] private GameObject escapeGroup;
    [SerializeField] private Image escapeStatusImage;

    [Header("Status Icons")]
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite completedSprite;

    [Header("Notification Popup")]
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TMP_Text popupTitleText;
    [SerializeField] private TMP_Text popupMessageText;
    [SerializeField] private AudioSource popupSound;

    [Header("Stage Completion Popup")]
    [SerializeField] private GameObject stageCompletionPanel;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        popupPanel.SetActive(false);
        stageCompletionPanel.SetActive(false);
    }

    #region Visibility
    public void ShowReactor()
    {
        reactorGroup.SetActive(true);
    }

    public void HideReactor()
    {
        reactorGroup.SetActive(false);
    }

    public void ShowMedbay()
    {
        medbayGroup.SetActive(true);
    }

    public void HideMedbay()
    {
        medbayGroup.SetActive(false);
    }

    public void ShowControlRoom()
    {
        controlRoomGroup.SetActive(true);
        Invoke(nameof(HideMedbay), 2f);
        Invoke(nameof(HideReactor), 2f);
    }

    public void HideControlRoom()
    {
        controlRoomGroup.SetActive(false);
    }

    public void ShowEscape()
    {
        escapeGroup.SetActive(true);
        Invoke(nameof(HideControlRoom), 2f);
    }

    public void HideEscape()
    {
        escapeGroup.SetActive(false);
    }

    #endregion

    #region Progress

    public void UpdateReactorProgress(int current, int required)
    {
        reactorProgressText.text = $"{current}/{required}";
    }

    public void UpdateMedbayProgress(int current, int required)
    {
        medbayProgressText.text = $"{current}/{required}";
    }

    public void UpdateControlRoomProgress(int current, int required)
    {
        controlRoomProgressText.text = $"{current}/{required}";
    }

    #endregion

    #region Status

    public void SetReactorActive()
    {
        reactorStatusImage.sprite = activeSprite;
    }

    public void SetReactorComplete()
    {
        reactorStatusImage.sprite = completedSprite;
    }

    public void SetMedbayActive()
    {
        medbayStatusImage.sprite = activeSprite;
    }

    public void SetMedbayComplete()
    {
        medbayStatusImage.sprite = completedSprite;
    }

    public void SetControlRoomActive()
    {
        controlRoomStatusImage.sprite = activeSprite;
    }

    public void SetControlRoomComplete()
    {
        controlRoomStatusImage.sprite = completedSprite;
    }

    public void SetEscapeActive()
    {
        escapeStatusImage.sprite = activeSprite;
    }

    public void SetEscapeComplete()
    {
        escapeStatusImage.sprite = completedSprite;
    }

    #endregion

    #region Popup

    public void ShowPopup(string title, string message)
    {
        popupSound.Play();
        popupPanel.SetActive(true);

        popupTitleText.text = title;
        popupMessageText.text = message;

        CancelInvoke(nameof(HidePopup));
        Invoke(nameof(HidePopup), 2f);
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }

    #endregion

    #region Stage Completion

    public void ShowStageCompletion()
    {
        stageCompletionPanel.SetActive(true);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartGame);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}