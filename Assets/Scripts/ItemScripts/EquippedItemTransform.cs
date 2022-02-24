using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class EquippedItemTransform : MonoBehaviourPunCallbacks
{
    public int parentID;
    
    // Start is called before the first frame update
    void Start()
    {
        photonView.RPC(nameof(BeChildObject), RpcTarget.AllBuffered, parentID);
    }

    [PunRPC]
    void BeChildObject(int parent, PhotonMessageInfo info)
    {
        GameObject player = null;
        foreach (var p in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (p.GetComponent<PhotonView>().ViewID == parent)
            {
                player = p;
            }
        }

        if (player != null)
        {
            transform.parent = player.transform;
        }
    }
}
