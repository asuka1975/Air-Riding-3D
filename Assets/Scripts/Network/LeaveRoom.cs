using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LeaveRoom : MonoBehaviourPunCallbacks
{
    /*
     ゲーム修了時にルームから退出するためのスクリプト
    ResultSceneのEventSystemにアタッチ
    */
    void Start()
    {
        PhotonNetwork.LeaveRoom();
    }
}
