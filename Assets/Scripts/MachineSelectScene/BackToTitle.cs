using System;
using System.Collections;
using System.Collections.Generic;
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
        GameObject.Find("SEManager").GetComponent<AudioSource>().PlayOneShot(audio, 0.6f);
        yield return new WaitForSeconds(audio.length);
        StartCoroutine(SceneTransitioner.Transition("Title Scene", ""));
    }
}