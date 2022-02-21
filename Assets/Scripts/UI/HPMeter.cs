using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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
                    _player = player.GetComponent<MachineBehavior>();
                }
            }

            if (_player != null) break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;
        _slider.value = _player.HP / 100;
    }
}
