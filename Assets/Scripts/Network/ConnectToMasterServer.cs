using UnityEngine;
using Photon.Pun;

/*
ボタンをクリックすると適当なマスターサーバに接続する
TitleSceneのCanvas/Buttonにアタッチする
アタッチ後OnClick()に登録する
*/

public class ConnectToMasterServer : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        Debug.Log("*** try to connect master server.");
        PhotonNetwork.ConnectUsingSettings();
    }
}