using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGame_UI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject EndGameMenuUI;
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

    //====// PAUSE MENU MANAGER //====//

    public void EnablePauseMenuUI()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        DisableInGameUI();
    }

    public void DisablePauseMenuUI()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        EanableInGameUI();
    }

    //====// END GAME MENU MANAGER //====//

    public void EnableEndGameMenuUI()
    {
        EndGameMenuUI.SetActive(true);
        Time.timeScale = 0;
        DisableInGameUI();
    }

    public void DisableEndGameMenuUI()
    {
        EndGameMenuUI.SetActive(false);
        Time.timeScale = 1;
        EanableInGameUI();
    }

    //====// IN GAME UI MANAGER //====//

    public void EanableInGameUI()
    {
        inGameUICanvasGroup.interactable = true;
        inGameUICanvasGroup.blocksRaycasts = true;
    }

    public void DisableInGameUI()
    {
        inGameUICanvasGroup.interactable = false;
        inGameUICanvasGroup.blocksRaycasts = false;
    }

    //====// IN GAME UI MANAGER //====//

    public string GetTimerValue()
    {
        return timerValue.text;
    }
}
