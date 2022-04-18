using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

class MachineSelectData {
    public int id;
}
public class SG : MonoBehaviour
{
    public AudioClip SE_startButtle;
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
        GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(SE_startButtle, 0.6f);
        yield return new WaitForSeconds(SE_startButtle.length);

        var waitMessage = GameObject.Find("WaitingMessage").GetComponent<TextMeshProUGUI>();
        for (int i = 0; PhotonNetwork.PlayerList.Length < NetworkManager.maxPlayer; i++, i %= 4)
        {
            waitMessage.text = "Wait other players" + new string('.', i);
            yield return new WaitForSeconds(0.1f);
        }
        
        var machine = GameObject.Find("MachineSelectManager");
        var id = machine.GetComponent<MachineSelectManager>().id;
        MachineSelectData data = new MachineSelectData(){ id = id };
        StartCoroutine(SceneTransitioner.Transition("CityTrial", data));
    }
}