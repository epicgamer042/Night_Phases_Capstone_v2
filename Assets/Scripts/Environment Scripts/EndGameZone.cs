using UnityEngine;

public class EndGameZone : MonoBehaviour
{
    [SerializeField] private InGame_UI inGameUI;
    [SerializeField] private EndGame_UI endGameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("GAME OVER TRIGGERED");
            inGameUI.EnableEndGameMenuUI();
            string leveltime = inGameUI.GetTimerValue();
            endGameUI.ShowFinalTime(leveltime);
        }
    }
}
