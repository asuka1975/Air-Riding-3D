using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //HACK: シーン読み込み直後に実行するとアイテムが生成されないため、Coroutineにして0.5秒待ってから実行させる
        StartCoroutine("GenerateItems");
    }
    IEnumerator GenerateItems()
    {
        yield return new WaitForSeconds(0.5f);
        int bombItemNum = 7;
        int cannonItemNum = 7;
        int recoverItemNum = 3;

        float range = 80; // アイテムの出現する範囲
        float center = 310*0.5f; // CenterPoleの座標 * Filed1のスケール

        for (int i = 0; i < bombItemNum; i++)
        {
            GameObject go = Instantiate(Resources.Load("BombItem"),
                new Vector3(Random.Range(center - range, center + range), 0.5f,
                    Random.Range(center - range, center + range)),
                transform.rotation) as GameObject;
        }
        for (int i = 0; i < cannonItemNum; i++)
        {
            GameObject go = Instantiate(Resources.Load("CannonItem"),
                new Vector3(Random.Range(center - range, center + range), 0.5f,
                    Random.Range(center - range, center + range)),
                transform.rotation) as GameObject;
        }
        for (int i = 0; i < recoverItemNum; i++) {
            GameObject go = Instantiate(Resources.Load("RecoverItem"),
                new Vector3(Random.Range(center - range, center + range), 0.5f,
                    Random.Range(center - range, center + range)),
                transform.rotation) as GameObject;
        }           
    }
}
