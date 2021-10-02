using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_machine : MonoBehaviour
{
    #region public variables
    public float LengthFromTarget;
    public float HeightFromTarget;
    public GameObject TargetObject;
    public float CameraSpeed;
    #endregion

    private Vector3 behind_camera_position;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        behind_camera_position = TargetObject.transform.position
                                 - (TargetObject.transform.forward * LengthFromTarget)
                                 + (TargetObject.transform.up * HeightFromTarget);
        this.transform.position = Vector3.Lerp(this.transform.position, behind_camera_position, CameraSpeed * Time.deltaTime );
        this.transform.LookAt(TargetObject.transform);
    }
}