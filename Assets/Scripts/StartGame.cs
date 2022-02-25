using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public AudioClip SE_select;
    public void OnClick()
    {
        StartCoroutine("playAudio", SE_select);
    }

    IEnumerator playAudio(AudioClip audio)
    {
        GetComponent<AudioSource>().PlayOneShot(audio);
        yield return new WaitForSeconds(audio.length);
        StartCoroutine(SceneTransitioner.Transition("MachineSelectScene", ""));
    }
}
