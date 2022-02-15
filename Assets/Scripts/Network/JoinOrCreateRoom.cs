using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class JoinOrCreateRoom : MonoBehaviourPunCallbacks
{
    public void OnClick()
    {
        Debug.Log("*** try to join or create room. *** ");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("部屋を作成する");
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }
}
