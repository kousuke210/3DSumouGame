using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            // Player1が落ちたので、Player2の勝利
            BattleResult.winnerMessage = "Player 2 の勝利！";
            GoToResult();
        }
        else if (other.CompareTag("Player2"))
        {
            // Player2が落ちたので、Player1の勝利
            BattleResult.winnerMessage = "Player 1 の勝利！";
            GoToResult();
        }
    }

    private void GoToResult()
    {
        // "ResultScene" の部分は、実際のリザルト画面のシーン名に変更してください
        SceneManager.LoadScene("ResultScreen");
    }
}