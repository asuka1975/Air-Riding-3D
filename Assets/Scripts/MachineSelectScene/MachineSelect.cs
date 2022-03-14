using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MachineSelect : MonoBehaviour
{
    public int id;
    public AudioMixer mixer;
    public AudioClip SE_click_button;
    public AudioClip SE_hover_button;
    public void OnClick()
    {
        GameObject.Find("SEManager").GetComponent<AudioSource>().PlayOneShot(SE_click_button, 0.5f); // click SE
        var machine = GameObject.Find("MachineSelectManager");
        machine.GetComponent<MachineSelectManager>().id = id;
        var str = "Selected machine ID is " + machine.GetComponent<MachineSelectManager>().id;
        Debug.Log(str);
        ButtonManager.SetInteractive("Button_StartGame", true);
    }
    public void PointerEnter()
    {
        GameObject.Find("SEManager").GetComponent<AudioSource>().PlayOneShot(SE_hover_button, 0.2f); // hover SE
    }
}