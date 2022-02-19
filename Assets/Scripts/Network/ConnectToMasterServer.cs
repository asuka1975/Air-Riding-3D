using UnityEngine;
using Photon.Pun;

/*
ゲームを開始すると適当なマスターサーバに接続する
TitleSceneのNetworkManagerにアタッチする
*/

public class ConnectToMasterServer : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        Debug.Log("*** try to connect master server.");
        PhotonNetwork.ConnectUsingSettings();
    }
}