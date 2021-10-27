using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public float Forward;
    public float Back;
    public float Rotation;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: 移動の仕方が原作と異なるので，今後改善する．
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.velocity = transform.forward * Forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.velocity = transform.forward * -Back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0), -Rotation);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0), Rotation);
        } 
    }
}
