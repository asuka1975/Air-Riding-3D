using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_machine : MonoBehaviour
{
    public GameObject target_obj;
    public float camera_speed;
    private Vector3 offset;

    Vector3 default_camera_position;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - target_obj.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target_obj.transform.position + offset, camera_speed * Time.deltaTime );
    }
}
