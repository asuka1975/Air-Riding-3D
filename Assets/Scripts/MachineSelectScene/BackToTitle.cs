using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    public AudioClip SE_cancel;
    public void OnClick()
    {
        StartCoroutine("transTitleScene");
        PhotonNetwork.LeaveRoom();
    }
    IEnumerator transTitleScene()
    {
        GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(SE_cancel, 0.6f);
        yield return new WaitForSeconds(SE_cancel.length);
        StartCoroutine(SceneTransitioner.Transition("Title Scene", ""));
    }
}