using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehavior : MonoBehaviour
{
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

    float charge = 0f; //percent

    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();

        rigidbody.position = new Vector3(rigidbody.position.x, floating, rigidbody.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        var position = rigidbody.position;
        var direction = transform.forward * forward;

        Debug.Log(charge);

        rigidbody.AddForce(direction); //常に前進方向に力を加える

        if (Input.GetKey(KeyCode.Space)) //スペースキーが押されたとき
        {
            if (charge <= 100)
            {
                charge += chargeRate * Time.deltaTime; //時間に応じてチャージ
                Debug.Log(charge);
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

        //マシンのhpが0以下になった際の処理(ゲームオーバー、爆発など) 1度だけ実行される
        if(HP <= 0.0f && !isMachineDestroyed)
        {
             MachineDestroyedEvent();
        }

        //TODO: 毎フレーム実行するのは効率悪い
        this.EquippedItem = transform.GetChild(0).gameObject;

        if(Input.GetKey(KeyCode.U))
        {
            this.EquippedItem.GetComponent<UseEquippedItem>().Use();
        }
    }

    void MachineDestroyedEvent()
    {
        this.isMachineDestroyed = true;
        Debug.Log("マシン" + this.gameObject.name + "は破壊されました.");
        Destroy(this.gameObject); //一応追加
    }

}