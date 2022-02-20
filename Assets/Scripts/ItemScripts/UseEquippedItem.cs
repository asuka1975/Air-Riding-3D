using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UseEquippedItem : MonoBehaviour
{
    public int maxCannonUse = 5;
    public int maxBombUse = 5;
    public int currentUse = 0;

    void DestroyItem()
    {
        Debug.Log("使用回数に達しました");
        Destroy(this.gameObject);
    }

    public void Use()
    {
        if(this.gameObject.name == "CannonItemEquipped(Clone)")
        {
            UseCannonItem();
        }
        if(this.gameObject.name == "BombItemEquipped(Clone)")
        {
            UseBombItem();
        }
        if(this.gameObject.name == "RecoverItemEquipped(Clone)")
        {
            UseRecoverItem();
        }
    }

    void UseCannonItem()
    {
        if(currentUse < maxCannonUse) {
            if(Input.GetKeyUp(KeyCode.W) ^ Input.GetKeyUp(KeyCode.S)) {
                Debug.Log("***CannonItemを使用***");
                Addressables.InstantiateAsync("Assets/Prefabs/Bullet.prefab", 
                    this.transform.position,
                    this.transform.rotation);

                currentUse += 1;
                Debug.Log(currentUse);
            }
        } else {
            Invoke(nameof(DestroyItem), 1.0f);
        }
    }
    void UseBombItem()
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
            Invoke(nameof(DestroyItem), 1.0f);
        }
    }
    void UseRecoverItem()
    {
        Debug.Log("*** RecoverItemを使用 ***");
        GameObject machineObj = this.gameObject.transform.parent.gameObject;
        machineObj.GetComponent<MachineBehavior>().HP += 15f;
        Destroy(this.gameObject);
    }
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
