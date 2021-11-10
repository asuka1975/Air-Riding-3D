using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("***");
        if (collision.gameObject.CompareTag("Player"))
        {
            var otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            var theta = transform.rotation.y;
            otherRigidbody.AddForce(new Vector3(Mathf.Cos(theta - Mathf.PI / 4), 0, Mathf.Sin(theta - Mathf.PI / 4)) * 600, ForceMode.Impulse);
        }
    }
}
