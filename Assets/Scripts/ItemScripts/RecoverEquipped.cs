using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverEquipped : MonoBehaviour, IITemUsable
{
    // Start is called before the first frame update
    void Start()
    {
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
