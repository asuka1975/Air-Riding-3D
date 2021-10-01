using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_machine : MonoBehaviour
{
    public float length_from_target;
    public float height_from_target;
    public GameObject target_obj;
    public float camera_speed;

    private Vector3 offset;
    private Vector3 camera_target_position;
    private Vector3 default_camera_position;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - target_obj.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camera_target_position = target_obj.transform.position
                                 - (target_obj.transform.forward * length_from_target)
                                 + (target_obj.transform.up * height_from_target);
        this.transform.position = Vector3.Lerp(this.transform.position, camera_target_position, camera_speed * Time.deltaTime );
        this.transform.LookAt(target_obj.transform);
    }
}