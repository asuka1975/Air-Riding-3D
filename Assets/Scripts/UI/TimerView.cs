using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    private TimeManager _timeManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var now = _timeManager.GetCurrentTime();
        string time = $"{now / 60} : {now % 60:00}";
        GetComponent<Text>().text = time;
    }
}
