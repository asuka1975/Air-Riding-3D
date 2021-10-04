using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehavior : MonoBehaviour
{
    public float Forward;
    public float Back;
    public float Rotation;
    public float minAngVel;
    public float maxAngVel;

    Rigidbody rigidbody;

    float angVel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Forward; // 常に前進

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

        angVel = Mathf.Clamp(rigidbody.angularVelocity.magnitude, minAngVel, maxAngVel);
        rigidbody.angularVelocity = angVel * rigidbody.angularVelocity.normalized;
    }
}
