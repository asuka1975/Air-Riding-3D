using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_machine : MonoBehaviour
{
    public GameObject target_obj;
    public float length_from_taregt;
    public float height_from_target;

    float dict_difference;

    Vector3 default_camera_position;

    // Start is called before the first frame update
    void Start()
    {
        //カメラの初期位置をセット
        default_camera_position = target_obj.transform.position 
                                  - (target_obj.transform.forward * length_from_taregt)
                                  + (target_obj.transform.up * height_from_target);
        this.transform.position = default_camera_position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO target_objの移動に合わせてカメラを移動させる(positionの移動のみ)

        //カメラは常にゲームオブジェクトを中心にとらえる(スピード感を出すためには改善した方が良い？)
        this.transform.LookAt(target_obj.transform);

        //TODO カメラを, target_objの背後に来るまでtarget_objを中心にゆっくりと回転させる
        dict_difference = Vector3.SignedAngle(target_obj.transform.forward, this.transform.forward, Vector3.up);
        Debug.Log("角度の差: "+ dict_difference);
    }
}
