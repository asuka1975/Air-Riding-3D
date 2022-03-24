using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class RecoverEquipped : MonoBehaviourPunCallbacks, IItemUsable
{
    public AudioClip SE_recover;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            StartCoroutine(nameof(UseAsync));
        }
    }

    private IEnumerator UseAsync()
    {
        while (transform.parent == null)
        {
            yield return new WaitForSeconds(0.1f);
        }

        Use();
    }

    public void Use()
    {
        GetComponentInParent<AudioSource>().PlayOneShot(SE_recover, 1.0f); // SE
        GameObject machineObj = transform.parent.gameObject;
        machineObj.GetComponent<MachineBehavior>().HP += 15f;
        photonView.RPC(nameof(PlayRecoverParticle), RpcTarget.All);
        StartCoroutine(RecoverEquippedLifetime());
    }

    [PunRPC]
    void PlayRecoverParticle()
    {
        var op = Addressables.InstantiateAsync(
            "Assets/FXIFIED/Stylized VFX Free Pack/Prefabs/FX_Healing_AOE_AA.prefab", 
            this.transform.position - this.transform.up * 0.1f, this.transform.rotation, this.transform
            );
        var g = op.WaitForCompletion();
        g.transform.localScale = new Vector3(g.transform.localScale.x * 0.3f, g.transform.localScale.y * 0.4f, g.transform.localScale.z * 0.3f);
    }
    IEnumerator RecoverEquippedLifetime()
    {
        yield return new WaitForSeconds(2.0f);
        OnUsed?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler OnUsed;
}
