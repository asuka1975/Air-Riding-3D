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
        StartCoroutine("transTitleScene", SE_cancel);
    }
    
    IEnumerator transTitleScene(AudioClip audio)
    {
        GetComponent<AudioSource>().PlayOneShot(audio);
        yield return new WaitForSeconds(audio.length);
        PhotonNetwork.LeaveRoom();
        StartCoroutine(SceneTransitioner.Transition("Title Scene", ""));
    }
}