using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public AudioClip SE_gameStart;
    public void OnClick()
    {
        StartCoroutine("transMachineSelectScene");
    }
    IEnumerator transMachineSelectScene()
    {
        GameObject.Find("SEManager").GetComponent<AudioSource>().PlayOneShot(SE_gameStart);
        yield return new WaitForSeconds(SE_gameStart.length);
        StartCoroutine(SceneTransitioner.Transition("MachineSelectScene", ""));
    }
}
