using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class InstantiateMachine : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var players = PhotonNetwork.PlayerList;
        Debug.Log("***" + players.Length);
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ルームは行ってます!!");
        PhotonNetwork.Instantiate("EmptyMachine", new Vector3(100, 10, 100), Quaternion.identity);
    }

}
