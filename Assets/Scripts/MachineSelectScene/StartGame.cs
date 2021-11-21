using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public void OnClick()
    {
        var machine = new Machine();

        StartCoroutine(SceneTransitioner.Transition("CityTrial", machine));
    }
}
public class Machine
{
    public int Id;
}