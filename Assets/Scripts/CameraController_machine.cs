using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController_machine : MonoBehaviour
{
    #region public variables
    public GameObject TargetObject;
    public float LengthFromTarget = 10f;
    public float HeightFromTarget = 3f;

    public float SideCameraLateralDistance = 6f;
    public float SideCameraForwardDistance = 6f;
    public float SideCameraHeight = 1f;
    public float CameraSpeed = 6f;
    #endregion

    private Vector3 behind_camera_position;
    private Vector3 right_camera_position;
    private Vector3 left_camera_position;
    private bool is_camera_located_right_side;
    private bool is_camera_located_behind;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //現在のTargetObjectの位置からカメラの目標位置を取得
        behind_camera_position = TargetObject.transform.position
                                 - (TargetObject.transform.forward * LengthFromTarget)
                                 + (TargetObject.transform.up * HeightFromTarget);
        right_camera_position = TargetObject.transform.position
                                 + (TargetObject.transform.forward * SideCameraForwardDistance)
                                 + (TargetObject.transform.right * SideCameraLateralDistance)
                                 + (TargetObject.transform.up * SideCameraHeight);
        left_camera_position = TargetObject.transform.position
                                 + (TargetObject.transform.forward * SideCameraForwardDistance)
                                 - (TargetObject.transform.right * SideCameraLateralDistance)
                                 + (TargetObject.transform.up * SideCameraHeight);

        //カメラ位置ベクトルをターゲットオブジェクト座標系に変換した際のx方向の値で、カメラが右にあるか左にあるかがわかる
        Vector3 camera_position_vec = (this.transform.position - TargetObject.transform.position).normalized;
        if(TargetObject.transform.InverseTransformVector(camera_position_vec).x > 0f) { is_camera_located_right_side = true; }
        else { is_camera_located_right_side = false; }
        if(Math.Abs(TargetObject.transform.InverseTransformVector(camera_position_vec).x) < 0.2f){is_camera_located_behind = true;}
        else{is_camera_located_behind = false;}

        //Vector3.Lerpを用いてカメラをなめらかに移動させる
        if(Input.GetKey("a") ) //カメラを右に向ける
        {
            if(is_camera_located_behind || !is_camera_located_right_side)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, left_camera_position, CameraSpeed * Time.deltaTime );
            }
            else
            {
                this.transform.position = Vector3.Lerp(this.transform.position, behind_camera_position, CameraSpeed * 3f * Time.deltaTime );
            }
        }
        else if (Input.GetKey("f") ) //カメラを左に向ける
        {
            if(is_camera_located_behind || is_camera_located_right_side)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, right_camera_position, CameraSpeed * Time.deltaTime );
            }
            else
            {
                this.transform.position = Vector3.Lerp(this.transform.position, behind_camera_position, CameraSpeed * 3f * Time.deltaTime );
            }
        }
        else{
            this.transform.position = Vector3.Lerp(this.transform.position, behind_camera_position, CameraSpeed * Time.deltaTime );
        }
        this.transform.LookAt(TargetObject.transform);
    }
}