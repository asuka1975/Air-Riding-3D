using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineSelect : MonoBehaviour
{
    public void OnClick()
    {
        var machine = new Machine();
        ButtonManager.SetInteractive("Button_StartGame", true);
        StartCoroutine(SceneTransitioner.Transition("MachineSelectScene", machine));
    }
}
public class Machine
{
    public int id;
}