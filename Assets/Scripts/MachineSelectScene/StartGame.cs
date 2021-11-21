using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    public void OnClick()
    {
        Button btn = GetComponent<Button>();
        btn.interactable = true;
        var machine = new Machine();

        StartCoroutine(SceneTransitioner.Transition("CityTrial", machine));
    }
}