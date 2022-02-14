using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // City Trial Scene から引き継いだデータを取得
        bool is_win = GameObject.FindWithTag("SharedParams").GetComponent<SharedParams>().Get<FinishedGameData>().is_win;
        // 勝敗を表示
        this.GetComponent<Text>().text = is_win ? "YOU WIN" : "YOU LOSE";
    }
}
