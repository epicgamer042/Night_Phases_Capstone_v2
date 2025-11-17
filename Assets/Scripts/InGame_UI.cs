using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGame_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerValue;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        timerValue.text = Time.timeSinceLevelLoad.ToString("F1") + "s";
    }


}
