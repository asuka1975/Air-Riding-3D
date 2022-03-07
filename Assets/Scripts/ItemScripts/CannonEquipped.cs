using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CannonEquipped : MonoBehaviourPunCallbacks, IItemUsable
{
    public int maxCannonUse;
    public int currentUse = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Use()
    {
        if(currentUse < maxCannonUse) {
            if(Input.GetKeyUp(KeyCode.W) ^ Input.GetKeyUp(KeyCode.S)) {
                Debug.Log("***CannonItemを使用***");
                photonView.RPC(nameof(CreateBullet), RpcTarget.All, transform.position, transform.rotation);

                currentUse += 1;
                Debug.Log(currentUse);
            }
        } else {
            OnUsed?.Invoke(this, EventArgs.Empty);
        }
    }

    [PunRPC]
    void CreateBullet(Vector3 position, Quaternion rotation, PhotonMessageInfo info)
    {
        Addressables.InstantiateAsync("Assets/Prefabs/Bullet.prefab", position, rotation);
    }

    public event EventHandler OnUsed;
}
