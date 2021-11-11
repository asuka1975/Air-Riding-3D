using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int bombItemNum = 3;
        int cannonItemNum = 3;
        int recoverItemNum = 3;

        for (int i = 0; i < bombItemNum; i++) {
            Addressables.InstantiateAsync("Assets/Prefabs/BombItem.prefab", 
                new Vector3(Random.value * 50, 0.0f, Random.value * 50), 
                this.transform.rotation);
        }
        for (int i = 0; i < cannonItemNum; i++) {
            Addressables.InstantiateAsync("Assets/Prefabs/CannonItem.prefab", 
                new Vector3(Random.value * 50, 0.0f, Random.value * 50), 
                this.transform.rotation);
        }
        for (int i = 0; i < recoverItemNum; i++) {
            Addressables.InstantiateAsync("Assets/Prefabs/RecoverItem.prefab", 
                new Vector3(Random.value * 50, 0.0f, Random.value * 50), 
                this.transform.rotation);
        }           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
