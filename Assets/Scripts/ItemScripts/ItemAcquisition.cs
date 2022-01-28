using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public struct ItemData{
    public int forward;
    public int right;
    public Vector3 rotation;
    public Vector3 scale;
}
public class ItemAcquisition : MonoBehaviour
{
    public Dictionary<string, ItemData> itemDatas;
    void Start()
    {
        itemDatas = new Dictionary<string, ItemData>()
        {
            {"CannonItem(Clone)", new ItemData(){
                forward = 10, right = 0, 
                rotation = new Vector3(0, 0, 0), 
                scale =  new Vector3(0.1f, 0.1f, 0.1f)
            }},
            {"BombItem(Clone)", new ItemData(){
                forward = -5, right = 0, 
                rotation = new Vector3(0, 0, 0), 
                scale =  new Vector3(1, 1, 1)
            }},
            {"RecoverItem(Clone)", new ItemData(){
                forward = 0, right = 0, 
                rotation = new Vector3(0, 0, 0), 
                scale =  new Vector3(1, 1, 1)
            }}
        };
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform n in other.gameObject.transform)
            {
                if (n.name.Contains("Equipped"))
                {
                    Destroy(n.gameObject);
                }
            }

            var op = Addressables.InstantiateAsync(
                string.Format("Assets/Prefabs/{0}Equipped.prefab",name.Replace("(Clone)", "")), 
                other.transform.position + other.transform.forward * itemDatas[name].forward + other.transform.right * itemDatas[name].right,
                other.transform.rotation,
                other.transform
            );
            GameObject equipped_item = op.WaitForCompletion();
            equipped_item.transform.localScale = itemDatas[name].scale;
            equipped_item.transform.Rotate(itemDatas[name].rotation);
            Destroy(gameObject);
        }
    }
}
