using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

struct ControllerState
{
    public bool Charging;
    public bool LeftTurning;
    public bool RightTurning;
}

public class MachineBehavior : MonoBehaviourPunCallbacks
{
    // 変数色々
    Camera maincamera;
    public int machineID;
    public GameObject EquippedItem;
    new Rigidbody rigidbody;
    GameObject machineIcon;

    // マシンの基本パラメータ
    public float HP = 100f;
    private float maxHP;
    public float defaultSpeed;
    public float rotate;
    private float floating = 0.5f;

    // チャージ関連
    public float chargeRate; //rate of increase per second
    public float chargeLv;
    public float maxChargeLv = 100.0f;
    public float dash; //ダッシュ時の倍率

    // 状態判定用
    private ControllerState KeyState;
    private bool isGameStarted = false;
    bool isMachineDestroyed = false;
    private bool isSceneTranslated = false;

    // SE用
    private AudioSource as_travel;
    private float volume_travel;
    private float pitch_travel;
    private AudioSource as_charge;
    public AudioClip SE_dash;
    private float volume_dash;

    //カメラズーム関連
    float camera_length;
    float camera_height;

    GameObject machineIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        machineIcon = this.transform.Find("MachineIcon").gameObject;
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.position = new Vector3(rigidbody.position.x, floating, rigidbody.position.z);

        // HPの最大値を覚えておく
        maxHP = HP;
        maincamera = Camera.main;
        //メインカメラのTargetObjectに自機を指定する
        if(photonView.IsMine)
        {
            maincamera.GetComponent<CameraController_machine>().TargetObject = this.gameObject;
        }

        KeyState = new ControllerState()
        {
            Charging = false, LeftTurning = false, RightTurning = false
        };
        //マシンアイコンの色を変更
        if(photonView.IsMine){
            machineIcon.GetComponent<Renderer>().material.color = Color.blue;
        }
        // AudioSourceの設定
        var audio = transform.Find("Audio").GetComponent<Transform>();
        as_travel = audio.Find("travel").GetComponent<AudioSource>(); // 走行音
        as_charge = audio.Find("charge").GetComponent<AudioSource>(); // チャージ音

        camera_length = maincamera.GetComponent<CameraController_machine>().LengthFromTarget;
        camera_height = maincamera.GetComponent<CameraController_machine>().HeightFromTarget;
    }

    void FixedUpdate()
    {
        if(!photonView.IsMine) return ;
        rigidbody = this.GetComponent<Rigidbody>();
        var position = rigidbody.position;

        rigidbody.AddForce(transform.forward.normalized * defaultSpeed, ForceMode.Acceleration); //常に前進方向に力を加える

        if (KeyState.Charging) //スペースキー、↕キーが押されているとき
        {
            if (chargeLv <= maxChargeLv)
            {
                chargeLv += chargeRate * Time.deltaTime; //時間に応じてチャージ
            }
            rigidbody.AddForce(-transform.forward.normalized * defaultSpeed * chargeLv/maxChargeLv, ForceMode.Acceleration); //ブレーキ
            maincamera.GetComponent<CameraController_machine>().LengthFromTarget = camera_length / 2;
            maincamera.GetComponent<CameraController_machine>().HeightFromTarget = camera_height / 2;
        }
        else
        {
            //スペースキーが押されていない時，マシンが浮く
            rigidbody.position = new Vector3(position.x, floating, position.z);
            rigidbody.AddForce(transform.forward * chargeLv * dash, ForceMode.Impulse);
            chargeLv = 0.0f;
            maincamera.GetComponent<CameraController_machine>().LengthFromTarget = camera_length;
            maincamera.GetComponent<CameraController_machine>().HeightFromTarget = camera_height;
        }
        
        if(KeyState.LeftTurning)
        {
            transform.Rotate (0, -rotate, 0, Space.World);
        }
        
        if(KeyState.RightTurning)
        {
            transform.Rotate (0, rotate, 0, Space.World);
        }
        
        // 走行音の音量調整
        if (KeyState.Charging || KeyState.LeftTurning || KeyState.RightTurning) {
            volume_travel = Mathf.Min(0.3f, volume_travel + 0.01f);
        } else {
            volume_travel = Mathf.Max(0.0f, volume_travel - 0.01f);
        }
        as_travel.volume = 0.07f + volume_travel;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted && PhotonNetwork.PlayerList.Length == GameObject.FindGameObjectsWithTag("Player").Length)
        {
            isGameStarted = true;
        } 
        
        if(photonView.IsMine)
        {
            KeyState.Charging = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) ||
                             Input.GetKey(KeyCode.DownArrow);
            KeyState.LeftTurning = Input.GetKey(KeyCode.LeftArrow);
            KeyState.RightTurning = Input.GetKey(KeyCode.RightArrow);

            if (isGameStarted && GameObject.FindGameObjectsWithTag("Player").Length == 1)
            {
                FinishedGameData data = new FinishedGameData(){ is_win = true };
                StartCoroutine(SceneTransitioner.Transition("Result Scene", data));
                PhotonNetwork.Destroy(this.gameObject);
            }

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

            if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) && this.EquippedItem != null)
            {
                try
                {
                    this.EquippedItem.GetComponent<IItemUsable>().Use();
                }
                catch(UnassignedReferenceException)
                {
                }
                catch(MissingReferenceException)
                {
                }
            }
            
            // 走行音のピッチ調整
            pitch_travel = Mathf.Min((rigidbody.velocity.magnitude / defaultSpeed - 0.27f) * 2.0f + 1.0f, 1.2f);
            as_travel.pitch = pitch_travel;

            // チャージ開始
            // if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
            //     as_charge.Play(); // SE
            // }

            // ダッシュ
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
                // as_charge.Stop();
                GetComponent<AudioSource>().PlayOneShot(SE_dash, (chargeLv / maxChargeLv) * 0.7f + 0.3f); // SE
                photonView.RPC(nameof(PlayDashParticle), RpcTarget.All); // パーティクル
            }
        }
    }

    void MachineDestroyedEvent()
    {
        this.isMachineDestroyed = true;
        // ResultSceneへ（破壊されたので負け）
        if (!isSceneTranslated) {
            isSceneTranslated = true;
            FinishedGameData data = new FinishedGameData(){ is_win = false };
            StartCoroutine(SceneTransitioner.Transition("Result Scene", data));
        }
    }

    public void CauseDamage(float damage)
    {
        HP -= damage;
        photonView.RPC(nameof(ShowDamageEffect), RpcTarget.All, damage, photonView.ViewID);
    }

    [PunRPC]
    void ShowDamageEffect(float damage, int viewId)
    {
        GameObject player = null;
        foreach (var p in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (p.GetPhotonView().ViewID == viewId)
            {
                player = p;
                break;
            }
        }

        if (player != null)
        {
            var op = Addressables.InstantiateAsync("Assets/Prefabs/DamageEffect.prefab",
                player.transform);
            var g = op.WaitForCompletion();
            var mesh = g.GetComponent<TextMeshPro>();
            if (mesh != null)
            {
                mesh.text = $"{-damage}";
                StartCoroutine(DamageEffectLifetime(g));
            }
            // particle
            Addressables.InstantiateAsync(
                "Assets/JMO Assets/WarFX/_Effects/Explosions/WFX_Explosion StarSmoke.prefab", 
                this.transform.position, this.transform.rotation, this.transform
                );
        }
    }

    IEnumerator DamageEffectLifetime(GameObject effect)
    {
        yield return new WaitForSeconds(1f);
        Destroy(effect);
    }

    [PunRPC]
    void PlayDashParticle()
    {
        var op = Addressables.InstantiateAsync(
            "Assets/JMO Assets/WarFX/_Effects (Mobile)/Explosions/WFXMR_Explosion Small.prefab", 
            this.transform.position - this.transform.forward * 2, this.transform.rotation, this.transform
            );
    }
}