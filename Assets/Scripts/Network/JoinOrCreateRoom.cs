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
        Debug.Log("*** Create new room. ***");
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ルームは行ってます22!!!!!");
    }
}
