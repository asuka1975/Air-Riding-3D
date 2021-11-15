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
    }
    void UseRecoverItem()
    {
        Debug.Log("*** RecoverItemを使用 ***");
    }
}
