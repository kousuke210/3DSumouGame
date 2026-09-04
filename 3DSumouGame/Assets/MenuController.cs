using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "SUMOUGameScene"; // 遷移先のゲームシーン名

    void Update()
    {
        // Xboxコントローラーの「Aボタン」が押された瞬間を検知する
        // (デフォルト設定では "Jump" がXboxコントローラーのAボタン、またはスペースキーに対応しています)
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        // ゲームシーンへ遷移
        SceneManager.LoadScene("SUMOU");
    }
}