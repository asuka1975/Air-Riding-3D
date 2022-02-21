using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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
    }

    // TODO commonalize among UI scripts.
    IEnumerator FindMachine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            var players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                if (player.GetComponent<PhotonView>().IsMine)
                {
                    _machineBehavior = player.GetComponent<MachineBehavior>();
                }
            }

            if (_machineBehavior != null) break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_machineBehavior == null) return;
        _charge.fillAmount = _machineBehavior.charge / 100;
    }
}
