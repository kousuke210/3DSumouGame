using UnityEngine;
using TMPro;


//カウントアップタイマー
public class TimerCount : MonoBehaviour
{
    //タイマー表示
    public TMP_Text timerText;

    //経過時間
    private float gameTimer = 0f;

    void Update()
    {
        gameTimer += Time.deltaTime;

        //秒表示
        int countUp = Mathf.FloorToInt(gameTimer);
        timerText.text = countUp.ToString("00") + "s";

    }
}
