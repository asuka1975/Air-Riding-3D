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
    public AudioClip SE_equip;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(SE_equip, 1.0f); // SE
    }

    public void Use()
    {
        if(currentUse < maxCannonUse) {
            if(Input.GetKeyUp(KeyCode.W) ^ Input.GetKeyUp(KeyCode.S)) {
                photonView.RPC(nameof(CreateBullet), RpcTarget.All, transform.position, transform.rotation);

                currentUse += 1;
            }
        } else {
            OnUsed?.Invoke(this, EventArgs.Empty);
        }
    }

    [PunRPC]
    void CreateBullet(Vector3 position, Quaternion rotation, PhotonMessageInfo info)
    {
        Instantiate(Resources.Load("Bullet"), position, rotation);
    }

    public event EventHandler OnUsed;
}
