using UnityEngine;
using TMPro; // TextMeshProを使う場合は必要（通常のTextの場合はUnityEngine.UIに変更してください）

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText; // 勝利者を表示するUIテキスト

    void Start()
    {
        // BattleResultに保存されていた勝者メッセージをUIに反映する
        if (resultText != null)
        {
            resultText.text = BattleResult.winnerMessage;
        }
    }
}