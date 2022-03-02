using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Photon.Pun;

public class DynamicCollider : MonoBehaviour
{
    public float reflection = 200;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Hit!!!!!!!!!");
            var otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            var reflect = Quaternion.AngleAxis(Random.value * 320 - 160, Vector3.up) * -other.transform.forward;
            otherRigidbody.AddForce(reflect * reflection, ForceMode.Impulse);

            other.GetComponent<MachineBehavior>().HP -= 10f;
        }
    }
}
