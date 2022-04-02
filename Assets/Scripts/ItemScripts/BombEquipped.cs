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
    public AudioClip SE_equip;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(SE_equip, 1.0f); // SE
    }

    public void Use()
    {
        if(currentUse < maxBombUse) {
            if(Input.GetKeyUp(KeyCode.W) ^ Input.GetKeyUp(KeyCode.S)) {
                float start_time = Time.time;
                StartCoroutine("ThroughBomb");

                currentUse += 1;
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
        Instantiate(Resources.Load("Bomb"), position, rotation);
    }
}
