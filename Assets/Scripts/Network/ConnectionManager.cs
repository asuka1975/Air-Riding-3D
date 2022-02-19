using UnityEngine;
using Photon.Pun;

/*
ゲームを開始すると適当なマスターサーバに接続する
TitleSceneのConnectionManagerにアタッチする
*/

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        Debug.Log("*** try to connect master server.");
        PhotonNetwork.ConnectUsingSettings();
    }
}