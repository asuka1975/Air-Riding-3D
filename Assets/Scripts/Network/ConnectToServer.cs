using UnityEngine;
using Photon.Pun;

/*
ボタンをクリックすると適当なゲームサーバに接続する
TitleSceneのCanvas/Buttonにアタッチする
アタッチ後OnClick()に登録する
*/

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public void OnClick()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}