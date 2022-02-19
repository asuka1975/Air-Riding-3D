using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class InstantiateMachine : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("*** try to join or create room. *** ");
        PhotonNetwork.JoinRandomRoom();
    }
    void Update()
    {
        var players = PhotonNetwork.PlayerList;
        Debug.Log("***" + players.Length);
        foreach(var photonView in PhotonNetwork.PhotonViewCollection){
            Debug.Log(photonView.gameObject.name + ":" + photonView.IsMine);
        }
        Debug.Log("=====");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("*** Create new room. ***");
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    // Update is called once per frame

    public override void OnJoinedRoom()
    {
        Debug.Log("ルームは行ってます!!");
        PhotonNetwork.Instantiate("EmptyMachine", new Vector3(100, 10, 100), Quaternion.identity);
    }

}
