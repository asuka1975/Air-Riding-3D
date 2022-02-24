using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static int maxPlayer = 2;

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("*** Create new room. ***");
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)maxPlayer;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }
}
