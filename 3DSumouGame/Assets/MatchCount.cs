using UnityEngine;
using TMPro;
using UnityEngine.Rendering;


//勝利数を管理するクラス
public class MatchCount : MonoBehaviour
{
    //1Pと2Pの勝利数を表示
    public TMP_Text player1Text;
    public TMP_Text player2Text;

    //1Pと2Pの勝利数
    private int player1Win = 0;
    private int player2Win = 0;


    //UI初期表示
    void Start()
    {
        UpdateUI();
    }

    //1P勝利時
    public void Player1Win()
    {
        if(player1Win < 2)
        {
            player1Win++;
        }
        UpdateUI();
    }

    //2P勝利時
    public void Player2Win()
    {
        if (player2Win < 2)
        {
            player2Win++;
        }
        UpdateUI();
    }

    //勝利数を更新
    void UpdateUI()
    {
        player1Text.text = GetPlayer1Marks();
        player2Text.text = GetPlayer2Marks();
    }

    //1P勝利数
    string GetPlayer1Marks()
    {
        switch(player1Win)
        {
            case 0:
                return "1P ○○";
            case 1: 
                return "1P <color=red>●○</color>";
            case 2:
                return "1P <color=red>●●</color>";

        }
        return "";
    }

    //2P勝利数
    string GetPlayer2Marks()
    {
        switch (player2Win)
        {
            case 0:
                return "2P ○○";
            case 1:
                return "2P <color=bull>○●</color>";
            case 2:
                return "2P <color=bull>●●</color>";

        }
        return "";
    }
}
