using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneAudioManager : MonoBehaviour
{
    public AudioClip BGM_win;
    public AudioClip BGM_lose;
    // Start is called before the first frame update
    void Start()
    {
        // City Trial Scene から引き継いだデータを取得
        bool is_win = GameObject.FindWithTag("SharedParams").GetComponent<SharedParams>().Get<FinishedGameData>().is_win;
        // 勝敗に応じて流すBGMを変える
        AudioSource audio_sourse = GetComponent<AudioSource>();
        audio_sourse.clip = is_win ? BGM_win : BGM_lose;
        audio_sourse.Play();
    }
}
