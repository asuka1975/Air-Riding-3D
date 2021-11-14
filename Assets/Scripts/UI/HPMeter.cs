using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPMeter : MonoBehaviour
{
    private Slider _slider;
    private MachineBehavior _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _player = GameObject.FindWithTag("Player").GetComponent<MachineBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _player.HP / 100;
    }
}
