using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehavior : MonoBehaviour
{
    public float forward = 30;
    public float back;

    public float rotation = 10;
    public float floating = 0.5f;
    public float minVel = 0;
    public float maxVel = 10;
    public float minAngVel = 0;
    public float maxAngVel = 1;

    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();

        rigidbody.position = new Vector3(rigidbody.position.x, floating, rigidbody.position.z);
        rigidbody.mass = 5;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        var position = rigidbody.position;
        var direction = transform.forward * forward;


        if (Input.GetKey(KeyCode.Space)) //�X�y�[�X�L�[�������ꂽ�Ƃ�
        {

        }
        else 
        {
            //�X�y�[�X�L�[��������Ă��Ȃ����C�}�V���������C�O�i�����ɗ͂��󂯂�
            rigidbody.position = new Vector3(position.x, floating, position.z);
            rigidbody.AddForce(direction);
        }

        if (Input.GetKey(KeyCode.DownArrow)) //���L�[�������ꂽ�Ƃ�
        {
           
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddTorque(new Vector3(0, -rotation, 0)); //���L�[�������ꂽ�Ƃ��C�}�V���͎��v���̃g���N���󂯂�
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rigidbody.angularVelocity = new Vector3();�@//���L�[��������Ă��Ȃ����C�}�V���̊p���x��0�ɂ���
        }

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            rigidbody.AddTorque(new Vector3(0, rotation, 0)); //���L�[�������ꂽ�Ƃ��C�}�V���͔����v���̃g���N���󂯂�
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rigidbody.angularVelocity = new Vector3();�@//���L�[��������Ă��Ȃ����C�}�V���̊p���x��0�ɂ���
        }

        //�ő呬�x�C�ő�p���x�ŃN���b�s���O
        var Vel = Mathf.Clamp(rigidbody.velocity.magnitude, minVel, maxVel);
        rigidbody.velocity = Vel * rigidbody.velocity.normalized;
        var angVel = Mathf.Clamp(rigidbody.angularVelocity.magnitude, minAngVel, maxAngVel);
        rigidbody.angularVelocity = angVel * rigidbody.angularVelocity.normalized;
    }
}
