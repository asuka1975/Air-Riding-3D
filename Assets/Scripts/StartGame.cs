using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public AudioClip SE_startGame;
    public void OnClick()
    {
        StartCoroutine("transMachineSelectScene");
    }
    IEnumerator transMachineSelectScene()
    {
        GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(SE_startGame, 0.6f);
        yield return new WaitForSeconds(SE_startGame.length);
        StartCoroutine(SceneTransitioner.Transition("MachineSelectScene", ""));
    }
}
