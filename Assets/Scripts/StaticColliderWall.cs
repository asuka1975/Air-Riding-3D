using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticColliderWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.otherCollider.gameObject.CompareTag("Player"))
            {
                var otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                otherRigidbody.AddForce(-contact.normal * 25, ForceMode.Impulse);
            }
        }
    }
}
