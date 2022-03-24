using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticColliderWall : MonoBehaviour
{
    public AudioClip SE_collision;
    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.otherCollider.gameObject.CompareTag("Player"))
            {
                contact.otherCollider.gameObject.GetComponent<AudioSource>().PlayOneShot(SE_collision, 0.3f);
                var otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                otherRigidbody.AddForce(-contact.normal * 25, ForceMode.Impulse);
            }
        }
    }
}
