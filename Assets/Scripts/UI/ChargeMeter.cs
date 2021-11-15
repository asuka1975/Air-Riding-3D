using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeMeter : MonoBehaviour
{
    private Image _charge;
    private MachineBehavior _machineBehavior;
    
    // Start is called before the first frame update
    void Start()
    {
        _charge = GetComponent<Image>();
        _machineBehavior = GameObject.FindWithTag("Player").GetComponent<MachineBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _charge.fillAmount = _machineBehavior.charge / 100;
    }
}
