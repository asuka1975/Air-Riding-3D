using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RecoverEquipped : MonoBehaviourPunCallbacks, IItemUsable
{
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
        Debug.Log("*** RecoverItemを使用 ***");
        GameObject machineObj = transform.parent.gameObject;
        machineObj.GetComponent<MachineBehavior>().HP += 15f;
        
        OnUsed?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler OnUsed;
}
