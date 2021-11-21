using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(SceneTransitioner.Transition("Title Scene", ""));
    }
}
