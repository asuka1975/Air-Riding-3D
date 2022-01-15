using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BombManager : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force_vector;
    public float survivalTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float force_rand = Random.Range(10f, 20f);
        float side_rand = Random.Range(-5f, 5f);
        force_vector = side_rand * transform.right - force_rand * transform.forward;
        rb.AddForce(force_vector, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        survivalTime -= Time.deltaTime;
        if (survivalTime <= 0)
        {
            Addressables.InstantiateAsync(
                "Assets/Prefabs/ExplosionFieldSmall.prefab",
                this.transform.position, this.transform.rotation
            );
            Destroy(this.gameObject);
        }
    }
}