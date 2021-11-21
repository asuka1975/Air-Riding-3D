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
        var machine = new Machine();
        machine.id = id;
        var str = "Selected machine ID is " + machine.id.ToString();
        Debug.Log(str);
        ButtonManager.SetInteractive("Button_StartGame", true);
    }
}
public class Machine
{
    public int id;
}