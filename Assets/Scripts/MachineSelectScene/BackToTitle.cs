using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    public void OnClick()
    {
        PhotonNetwork.LeaveRoom();
        StartCoroutine(SceneTransitioner.Transition("Title Scene", ""));
    }
}