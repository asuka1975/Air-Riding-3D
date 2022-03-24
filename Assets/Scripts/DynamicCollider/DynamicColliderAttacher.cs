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
        GameObject[] playersObj = GameObject.FindGameObjectsWithTag("Player");
        while (playersObj.Length < NetworkManager.maxPlayer || !IsDynamicColliderAllAttached())
        {
            foreach(var p in playersObj)
            {
                if(p.GetComponent<PhotonView>().IsMine || p.GetComponent<DynamicCollider>() != null) continue;
                p.AddComponent<DynamicCollider>();
                p.GetComponent<BoxCollider>().isTrigger = true;
            }

            yield return new WaitForSeconds(0.1f);
            playersObj = GameObject.FindGameObjectsWithTag("Player");
        }
    }

    bool IsDynamicColliderAllAttached() {
        GameObject[] playersObj = GameObject.FindGameObjectsWithTag("Player");
        foreach(var p in playersObj) {
            if(p.GetComponent<DynamicCollider>() == null) return false;
        }
        return true;
    }
}
