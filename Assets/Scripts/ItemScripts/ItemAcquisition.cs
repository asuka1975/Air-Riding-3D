using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ItemAcquisition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Addressables.InstantiateAsync(string.Format("Assets/Prefabs/{0}Equipped.prefab",
                name.Replace("(Clone)", "")), other.transform);
            Destroy(gameObject);
        }
    }
}
