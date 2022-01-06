using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWall : MonoBehaviour
{
    public float Damage = 0.1f;

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player")) {
            other.gameObject.GetComponent<MachineBehavior>().HP -= Damage;
        }
    }
}
