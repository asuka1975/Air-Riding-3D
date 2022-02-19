using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MachineBehavior : MonoBehaviourPunCallbacks
{
    Camera maincamera;
    public GameObject EquippedItem;
    public float forward = 30;
    public float back;

    public float rotation = 10;
    public float floating = 0.5f;
    public float minVel = 0;
    public float maxVel = 10;
    public float minAngVel = 0;
    public float maxAngVel = 1;
    public float chargeRate = 50f; //rate of increase per second
    public bool isMachineDestroyed = false;
    public float HP = 100f;
    public float dash = 5; //ダッシュ時の倍率

    public float charge = 0f; //percent

    new Rigidbody rigidbody;
    new GameObject machine;

    public struct MachineData
    {
        public string path;
        public Vector3 scale;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.position = new Vector3(rigidbody.position.x, floating, rigidbody.position.z);
        // 引き継いだデータを取得
        var id = GameObject.FindWithTag("SharedParams").GetComponent<SharedParams>().Get<MachineSelectData>().id;
        // Debug.Log(id);
        // マシンを生成
        var machineDatas = new Dictionary<int, MachineData>()
        {
            {0, new MachineData(){ path = "Assets/Aircrafts/Prefabs/Aircraft 1.prefab", scale = new Vector3(0.02f, 0.02f, 0.02f) }},
            {1, new MachineData(){ path = "Assets/Aircrafts/Prefabs/Aircraft 21.prefab", scale = new Vector3(0.02f, 0.02f, 0.02f) }},
            {2, new MachineData(){ path = "Assets/Aircrafts/Prefabs/Aircraft 22.prefab", scale = new Vector3(0.02f, 0.02f, 0.02f) }}
        };
        var op = Addressables.InstantiateAsync(machineDatas[id].path, this.transform.position, this.transform.rotation, this.transform);
        machine = op.WaitForCompletion();
        machine.transform.localScale = machineDatas[id].scale;

        maincamera = Camera.main;
        //メインカメラを自機の子要素にする
        if(photonView.IsMine)
        {
            //maincamera.transform.parent = this.gameObject.transform;
            //maincamera.transform.position = this.gameObject.transform.position;
            maincamera.GetComponent<CameraController_machine>().TargetObject = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        var position = rigidbody.position;
        var direction = transform.forward * forward;

        // Debug.Log(charge);

        rigidbody.AddForce(direction); //常に前進方向に力を加える


        if(photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space)) //スペースキーが押されたとき
            {
                if (charge <= 100)
                {
                    charge += chargeRate * Time.deltaTime; //時間に応じてチャージ
                }
                rigidbody.AddForce(-direction * charge/100); //徐々にブレーキ
            }
            else
            {
                //スペースキーが押されていない時，マシンが浮く
                rigidbody.position = new Vector3(position.x, floating, position.z);

                rigidbody.AddForce(direction*charge*dash); //チャージに応じてダッシュ
                charge = 0; //reset
            }

            if (Input.GetKey(KeyCode.DownArrow)) //↓キーが押されたとき
            {

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidbody.AddTorque(new Vector3(0, -rotation, 0)); //←キーが押されたとき，マシンは時計回りのトルクを受ける
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                rigidbody.angularVelocity = new Vector3(); //←キーが押されていない時，マシンの角速度を0にする
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody.AddTorque(new Vector3(0, rotation, 0)); //→キーが押されたとき，マシンは反時計回りのトルクを受ける
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                rigidbody.angularVelocity = new Vector3(); //→キーが押されていない時，マシンの角速度を0にする
            }

            //最大角速度でクリッピング
            var angVel = Mathf.Clamp(rigidbody.angularVelocity.magnitude, minAngVel, maxAngVel);
            rigidbody.angularVelocity = angVel * rigidbody.angularVelocity.normalized;

        }

        //マシンのhpが0以下になった際の処理(ゲームオーバー、爆発など) 1度だけ実行される
        if(HP <= 0.0f && !isMachineDestroyed)
        {
             MachineDestroyedEvent();
        }

        if(Input.GetKeyUp(KeyCode.U))
        {
            foreach (Transform n in this.gameObject.transform)
            {
               if (n.name.Contains("Equipped"))
               {
                   this.EquippedItem = n.gameObject;
               }
            } 

            try
            {
                this.EquippedItem.GetComponent<UseEquippedItem>().Use();
            }
            catch(UnassignedReferenceException)
            {
                Debug.Log("*** アイテムが装備されていません");
            }


        }
    }

    void MachineDestroyedEvent()
    {
        this.isMachineDestroyed = true;
        Debug.Log("マシン" + this.gameObject.name + "は破壊されました.");
        Destroy(this.gameObject); //一応追加
    }

}