using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
                photonView.RPC(nameof(CreateBullet), RpcTarget.All, transform.position, transform.rotation, transform.parent.GetComponent<PhotonView>().ViewID);

                currentUse += 1;
                Debug.Log(currentUse);
            }
        } else {
            OnUsed?.Invoke(this, EventArgs.Empty);
        }
    }

    [PunRPC]
    void CreateBullet(Vector3 position, Quaternion rotation, int viewId, PhotonMessageInfo info)
    {
        var handle = Addressables.InstantiateAsync("Assets/Prefabs/Bullet.prefab", position, rotation);
        handle.Completed += op => {
            if(op.Status == AsyncOperationStatus.Succeeded)
            {
                if (op.Result == null) return;
                op.Result.GetComponent<BulletManager>().ownerId = viewId;
            }
        };
    }

    public event EventHandler OnUsed;
}
