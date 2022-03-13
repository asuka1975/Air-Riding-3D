using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CannonEquipped : MonoBehaviour, IItemUsable
{
    public AudioClip SE_acquisition;
    public int maxCannonUse = 5;
    public int currentUse = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<AudioSource>().PlayOneShot(SE_acquisition, 1.0f); // SE
    }

    public void Use()
    {
        if(currentUse < maxCannonUse) {
            if(Input.GetKeyUp(KeyCode.W) ^ Input.GetKeyUp(KeyCode.S)) {
                Debug.Log("***CannonItemを使用***");
                Addressables.InstantiateAsync("Assets/Prefabs/Bullet.prefab", 
                    transform.position,
                    transform.rotation);

                currentUse += 1;
                Debug.Log(currentUse);
            }
        } else {
            OnUsed?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler OnUsed;
}
