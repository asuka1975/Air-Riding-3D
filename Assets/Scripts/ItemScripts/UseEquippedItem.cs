using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UseEquippedItem : MonoBehaviour
{
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
        Debug.Log("***CannonItemを使用***");
        Addressables.InstantiateAsync("Assets/Prefabs/Bullet.prefab", 
            this.transform.position,
            this.transform.rotation);
    }
    void UseBombItem()
    {
        Debug.Log("*** BombItemを使用 ***");
        for (int n = 0; n < 12; n++)
        {
            Addressables.InstantiateAsync("Assets/Prefabs/Bomb.prefab", 
                this.transform.position,
                this.transform.rotation);
        }
    }
    void UseRecoverItem()
    {
        Debug.Log("*** RecoverItemを使用 ***");
    }
}
