using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGame_UI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private CanvasGroup inGameUICanvasGroup;
    [SerializeField] private TextMeshProUGUI timerValue;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        timerValue.text = Time.timeSinceLevelLoad.ToString("F1") + "s";
    }

    public void EnablePauseMenuUI()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; // Freeze gameplay

        // Disable interaction with gameplay UI while in pause menu
        inGameUICanvasGroup.interactable = false;
        inGameUICanvasGroup.blocksRaycasts = false;
    }

    public void DisablePauseMenuUI()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1; // Resume gameplay

        // Re-enable interaction with gameplay UI when leaving pause menu
        inGameUICanvasGroup.interactable = true;
        inGameUICanvasGroup.blocksRaycasts = true;
    }
}
