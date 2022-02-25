using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
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
        GameObject.Find("Button_StartGame").GetComponent<Button>().interactable = false;
        StartCoroutine(nameof(WaitJoinPlayers));
    }
    
    private IEnumerator WaitJoinPlayers()
    {
        var waitMessage = GameObject.Find("WaitingMessage").GetComponent<TextMeshProUGUI>();
        for (int i = 0; PhotonNetwork.PlayerList.Length < NetworkManager.maxPlayer; i++, i %= 4)
        {
            waitMessage.text = "Wait other players" + new string('.', i);
            yield return new WaitForSeconds(2.5f);
        }
        
        var machine = GameObject.Find("MachineSelectManager");
        var id = machine.GetComponent<MachineSelectManager>().id;
        MachineSelectData data = new MachineSelectData(){ id = id };
        StartCoroutine(SceneTransitioner.Transition("CityTrial", data));
    }
}