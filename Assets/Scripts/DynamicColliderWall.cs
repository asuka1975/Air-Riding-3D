using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColliderWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            var theta = transform.rotation.y;
            otherRigidbody.AddForce(new Vector3(Mathf.Cos(theta - Mathf.PI / 4), 0, Mathf.Sin(theta - Mathf.PI / 4)) * 600, ForceMode.Impulse);
        }
    }
}
