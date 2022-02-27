using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DynamicColliderAttacher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(WaitState));
    }

    IEnumerator WaitState()
    {
        var players = PhotonNetwork.PlayerList;
        while (players.Length<=NetworkManager.maxPlayer)
        {
            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!");
            yield return new WaitForSeconds(0.1f);
        }
    }
}
