using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineSelect : MonoBehaviour
{
    public int id;

    public void OnClick()
    {

        var machine = GameObject.Find("MachineSelectManager");
        machine.GetComponent<MachineSelectManager>().id = id;
        ButtonManager.SetInteractive("Button_StartGame", true);
    }
}