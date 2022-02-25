using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineSelect : MonoBehaviour
{
    public int id;
    public AudioClip SE_button;

    public void OnClick()
    {
        GetComponent<AudioSource>().PlayOneShot(SE_button);
        var machine = GameObject.Find("MachineSelectManager");
        machine.GetComponent<MachineSelectManager>().id = id;
        var str = "Selected machine ID is " + machine.GetComponent<MachineSelectManager>().id;
        Debug.Log(str);
        ButtonManager.SetInteractive("Button_StartGame", true);
    }
}