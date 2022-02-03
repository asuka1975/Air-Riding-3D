using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BulletManager : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force_vector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        force_vector = transform.forward * 100f + transform.up * 2f;
        rb.AddForce(force_vector, ForceMode.Impulse);
        transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: 自分にもヒットするので直す
        if (other.CompareTag("Player"))
        {
            //TODO
            //他の(自機以外)プレイヤーにHITしたら爆発
            //オンライン対応時に実装
        }
        else
        {
            Addressables.InstantiateAsync(
                "Assets/JMO Assets/WarFX/_Effects (Mobile)/Explosions/WFXMR_ExplosiveSmokeGround Big.prefab",
                this.transform.position, this.transform.rotation
                );
            Addressables.InstantiateAsync(
                "Assets/Prefabs/ExplosionFieldLarge.prefab",
                this.transform.position, this.transform.rotation
                );
            Destroy(this.gameObject);
            
        }

    }
}
