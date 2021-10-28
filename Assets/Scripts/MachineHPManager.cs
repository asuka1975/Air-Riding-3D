using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineHPManager : MonoBehaviour
{
    //マシンのHPを管理
    // マシンのHPを変更する場合はpublicなメソッド (gt)
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0.0f)
        {
            MachineDestroyedEvent();
        }
    }

    void MachineDestroyedEvent()
    {
        //HPが0になったら呼び出される
        //ゲームオーバ、マシンの破壊等
        Debug.Log("あたしは死んだ。スイーツ(笑)");
    }
}
