using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int timeLimit = 180;

    private float _startTime = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var now = Time.time;
        if (now - _startTime > timeLimit)
        {
            // 時間を過ぎたらDraw？
            Debug.Log("Draw");
        }
    }

    public int GetCurrentTime()
    {
        var elapsed = Time.time - _startTime;
        return timeLimit - (int)elapsed;
    }
}
