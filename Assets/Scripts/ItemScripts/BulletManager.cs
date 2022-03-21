using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Photon.Pun;

public class BulletManager : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force_vector;
    public int ownerId = -1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.Rotate(0, -90, 0);
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
        // 自分にあたったときは何もしない
        if (other.CompareTag("Player") &&
            (ownerId == -1 || other.gameObject.GetComponent<PhotonView>().ViewID == ownerId)) return;

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
