using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SG : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.interactable = false;
    }
    public void OnClick()
    {
        var machine = new Machine();
        var str = "Selected machine ID is " + machine.id.ToString();
        Debug.Log(str);
        StartCoroutine(SceneTransitioner.Transition("CityTrial", machine));
    }
}