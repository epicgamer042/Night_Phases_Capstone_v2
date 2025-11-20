using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGame_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalTime;

    public void ShowFinalTime(string leveltime)
    {
        finalTime.text = leveltime;
    }

    public void ExitGame()
    {
        //Exit in build application
        Application.Quit();

        //Exit in Unity Editor (UNITY_EDITOR is not defined in a built game)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
