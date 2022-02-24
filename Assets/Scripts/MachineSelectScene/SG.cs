using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

class MachineSelectData {
    public int id;
}
public class SG : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.interactable = false;
    }
    public void OnClick()
    {
        PhotonNetwork.JoinRandomRoom();
        StartCoroutine(nameof(WaitJoinPlayers));
    }
    
    private IEnumerator WaitJoinPlayers()
    {
        while (PhotonNetwork.PlayerList.Length < NetworkManager.maxPlayer)
        {
            yield return new WaitForSeconds(2.5f);
        }
        
        var machine = GameObject.Find("MachineSelectManager");
        var id = machine.GetComponent<MachineSelectManager>().id;
        MachineSelectData data = new MachineSelectData(){ id = id };
        StartCoroutine(SceneTransitioner.Transition("CityTrial", data));
    }
}