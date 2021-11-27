using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMachineBehavior : MonoBehaviour
{
    new Rigidbody rigidbody;
    public float forward = 30;
    public float rotation = 10;
    public float floating = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        
        rigidbody.position = new Vector3(rigidbody.position.x, floating, rigidbody.position.z);
    }

    private void Update()
    {
        var position = rigidbody.position;
        var direction = transform.forward * forward;
        rigidbody.position = new Vector3(position.x, floating, position.z);
        rigidbody.AddTorque(new Vector3(0, -rotation, 0));
        rigidbody.AddForce(direction);
    }
    
    
}
