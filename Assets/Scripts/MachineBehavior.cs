using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehavior : MonoBehaviour
{
    public float Forward;
    public float Back;
    public float Rotation;
    public float minVel;
    public float maxVel;
    public float minAngVel;
    public float maxAngVel;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.forward * Forward;
        //float y = GetComponent<Rigidbody>().velocity.y;
        //GetComponent<Rigidbody>().velocity = new Vector3(direction.x, y, direction.z);
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.AddForce(direction);

        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddTorque(new Vector3(0, -Rotation, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddTorque(new Vector3(0, Rotation, 0));
        }

        var Vel = Mathf.Clamp(rigidbody.velocity.magnitude, minVel, maxVel);
        rigidbody.velocity = Vel * rigidbody.velocity.normalized;
        var angVel = Mathf.Clamp(rigidbody.angularVelocity.magnitude, minAngVel, maxAngVel);
        rigidbody.angularVelocity = angVel * rigidbody.angularVelocity.normalized;
    }
}
