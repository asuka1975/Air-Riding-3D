using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverEquipped : MonoBehaviour, IItemUsable
{
    public AudioClip SE_recover;
    // Start is called before the first frame update
    void Start()
    {
        Use();
    }

    public void Use()
    {
        Debug.Log("*** RecoverItemを使用 ***");
        GetComponentInParent<AudioSource>().PlayOneShot(SE_recover, 1.0f); // SE
        GameObject machineObj = transform.parent.gameObject;
        machineObj.GetComponent<MachineBehavior>().HP += 15f;
        
        OnUsed?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler OnUsed;
}
