using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    // 指定した名前のシーンへ遷移
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // よく使う遷移のショートカットメソッド
    public void GoToGame()
    {
        SceneManager.LoadScene("SUMOU");
    }

    public void GoToResult()
    {
        SceneManager.LoadScene("ResultScreen");
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}