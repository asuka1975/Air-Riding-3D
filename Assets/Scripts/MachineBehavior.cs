using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MachineBehavior : MonoBehaviourPunCallbacks
{
    Camera maincamera;
    public int machineID;
    public GameObject EquippedItem;
    public float forward = 80;
    public float back;

    public float rotateSpeed = 100;
    public float floating = 1.5f;
    public float chargeRate = 50f; //rate of increase per second
    public float HP = 100f;
    public float maxHP;
    public float defaultSpeed;
    public float chargeLv = 0.0f;
    public float maxChargeLv = 100.0f;
    public float dash = 5; //ダッシュ時の倍率

    new Rigidbody rigidbody;

    bool isMachineDestroyed = false;
    bool isCharging = false;
    bool isRightTurning = false;
    bool isLeftTurning = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.position = new Vector3(rigidbody.position.x, floating, rigidbody.position.z);

        // HPの最大値を覚えておく
        maxHP = HP;
        maincamera = Camera.main;
        //メインカメラのTargetObjectに自機を指定する
        if(photonView.IsMine)
        {
            Debug.Log("*** ", maincamera);
            Debug.Log("*** ", maincamera.GetComponent<CameraController_machine>());
            Debug.Log("*** ", maincamera.GetComponent<CameraController_machine>().TargetObject);
            maincamera.GetComponent<CameraController_machine>().TargetObject = this.gameObject;
        }
    }

    void FixedUpdate()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        var position = rigidbody.position;
        var direction = transform.forward;

        Debug.Log(transform.forward.normalized * defaultSpeed);
        rigidbody.AddForce(transform.forward.normalized * defaultSpeed, ForceMode.Acceleration); //常に前進方向に力を加える

        if(isCharging)
        {
            rigidbody.AddForce(-direction * chargeLv / 10); //ブレーキ
        }
        if(isRightTurning)
        {
            rigidbody.AddTorque(new Vector3(0, -rotateSpeed, 0), ForceMode.Acceleration);
        }
        if(isLeftTurning)
        {
            rigidbody.AddTorque(new Vector3(0, rotateSpeed, 0), ForceMode.Acceleration);
        }
        if(!isLeftTurning && !isRightTurning)
        {
        }
    }


    // Update is called once per frame
    void Update()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        var position = rigidbody.position;
        var direction = transform.forward * forward;

        // Debug.Log(charge);

        if(photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space) ^ Input.GetKey(KeyCode.UpArrow) ^ Input.GetKey(KeyCode.DownArrow)) //スペースキーが押されたとき
            {
                Debug.Log("チャージ中");
                Debug.Log(chargeLv);
                isCharging = true;

                if (chargeLv <= maxChargeLv)
                {
                    chargeLv += chargeRate * Time.deltaTime; //時間に応じてチャージ
                }
            }
            else
            {
                isCharging = false;
                //スペースキーが押されていない時，マシンが浮く
                rigidbody.position = new Vector3(position.x, floating, position.z);

                //rigidbody.AddForce(direction*charge*dash); //チャージに応じてダッシュ
                rigidbody.AddForce(transform.forward * chargeLv * dash, ForceMode.Impulse);
                chargeLv = 0.0f;
            }

            if (Input.GetKey(KeyCode.LeftArrow)) { isRightTurning = true; }
            else{ isRightTurning = false; }

            if (Input.GetKey(KeyCode.RightArrow)) { isLeftTurning = true; }
            else{ isLeftTurning = false; }

            //マシンのhpが0以下になった際の処理(ゲームオーバー、爆発など) 1度だけ実行される
            if(HP <= 0.0f && !isMachineDestroyed)
            {
                MachineDestroyedEvent();
            }

            // 最大HPでクリッピング
            HP = Mathf.Clamp(HP, 0, maxHP);

            //マシンのhpが0以下になった際の処理(ゲームオーバー、爆発など) 1度だけ実行される
            if(HP <= 0.0f && !isMachineDestroyed)
            {
                 MachineDestroyedEvent();
            }

            foreach (Transform n in this.gameObject.transform)
            {
                if (n.name.Contains("Equipped"))
                {
                    this.EquippedItem = n.gameObject;
                }
            }

            if (Input.GetKeyUp(KeyCode.W) ^ Input.GetKeyUp(KeyCode.S))
            {
                try
                {
                    this.EquippedItem.GetComponent<IITemUsable>().Use();
                }
                catch(UnassignedReferenceException)
                {
                    Debug.Log("*** アイテムが装備されていません");
                }
                catch(MissingReferenceException)
                {
                    Debug.Log("*** アイテムがすでに削除されています");
                }
            }
        }
    }

    void MachineDestroyedEvent()
    {
        this.isMachineDestroyed = true;
        Debug.Log("マシン" + this.gameObject.name + "は破壊されました.");
        // Destroy(this.gameObject); //一応追加
        // ResultSceneへ（破壊されたので負け）
        FinishedGameData data = new FinishedGameData(){ is_win = false };
        StartCoroutine(SceneTransitioner.Transition("Result Scene", data));
        PhotonNetwork.Destroy(this.gameObject);
    }

}