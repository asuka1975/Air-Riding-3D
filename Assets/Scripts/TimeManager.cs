using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FinishedGameData {
    public bool is_win;
}

public class TimeManager : MonoBehaviour
{
    public int timeLimit = 180;

    private float _startTime = 0.0f;
    private bool isSceneTranslated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var now = Time.time;
        if (now - _startTime > timeLimit && !isSceneTranslated)
        {
            // ResultSceneへ（生き残ったので勝ち）
            isSceneTranslated = true;
            Debug.Log("Game Finished!");
            GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
            FinishedGameData data = new FinishedGameData(){ is_win = true };
            StartCoroutine(SceneTransitioner.Transition("Result Scene", data));
        }
    }

    public int GetCurrentTime()
    {
        var elapsed = Time.time - _startTime;
        return timeLimit - (int)elapsed;
    }
}
