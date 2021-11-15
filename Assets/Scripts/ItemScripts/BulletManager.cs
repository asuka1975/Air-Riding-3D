using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            other.GetComponent<MachineBehavior>().HP -= 10f; 
        }

    }
}
