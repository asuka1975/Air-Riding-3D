using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force_vector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        float force_rand = Random.Range(10f, 50f);
        force_vector = transform.forward * force_rand * -1f;
        
        float side_rand = Random.Range(-45f, 45f);
        float up_rand = Random.Range(0f, 45f);
        force_vector = Quaternion.Euler(up_rand, side_rand, 0) * force_vector;
        
        rb.AddForce(force_vector, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
