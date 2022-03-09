using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BombEquipped : MonoBehaviour, IItemUsable
{
    public int maxBombUse = 5;
    public int currentUse = 0;
    public AudioClip SE_acquisition;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<AudioSource>().PlayOneShot(SE_acquisition, 1.0f);
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
        for (int n = 0; n < 5; n++) {
            Addressables.InstantiateAsync("Assets/Prefabs/Bomb.prefab", 
                this.transform.position, this.transform.rotation
            );
            yield return new WaitForSeconds(0.1f);
        }
    }
}
