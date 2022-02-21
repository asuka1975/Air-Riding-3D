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
        StartCoroutine("FindMachine");
        _machineBehavior = GameObject.FindWithTag("Player").GetComponent<MachineBehavior>();
    }

    // TODO commonalize among UI scripts.
    IEnumerator FindMachine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            var player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                _machineBehavior = player.GetComponent<MachineBehavior>();
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_machineBehavior == null) return;
        _charge.fillAmount = _machineBehavior.charge / 100;
    }
}
