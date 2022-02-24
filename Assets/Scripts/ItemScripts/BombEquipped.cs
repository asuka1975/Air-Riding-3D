using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BombEquipped : MonoBehaviourPunCallbacks, IItemUsable
{
    public int maxBombUse = 5;
    public int currentUse = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Use()
    {
        if(currentUse < maxBombUse) {
            if(Input.GetKeyUp(KeyCode.W) ^ Input.GetKeyUp(KeyCode.S)) {
                Debug.Log("*** BombItemを使用 ***");
                float start_time = Time.time;
                StartCoroutine("ThroughBomb");

                currentUse += 1;
                Debug.Log(currentUse);
            }
        } else {
            OnUsed?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler OnUsed;
    
    IEnumerator ThroughBomb()
    {
        var t = transform;
        for (int n = 0; n < 5; n++) {
            photonView.RPC(nameof(CreateBomb), RpcTarget.All, t.position, t.rotation);
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    [PunRPC]
    void CreateBomb(Vector3 position, Quaternion rotation, PhotonMessageInfo info)
    {
        Addressables.InstantiateAsync("Assets/Prefabs/Bomb.prefab", 
            position, rotation
        );
    }
}
