using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class VelocityView : MonoBehaviour
{
    private Text _velocityLabel;
    private Rigidbody _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _velocityLabel = GetComponent<Text>();
        StartCoroutine(FindMachine());
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
                    _player = player.GetComponent<Rigidbody>();
                    yield break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;
        _velocityLabel.text = $"{_player.velocity.magnitude:F2}";
    }
}
