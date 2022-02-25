using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class MachineSelectData {
    public int id;
}
public class SG : MonoBehaviour
{
    public AudioClip SE_select;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.interactable = false;
    }
    public void OnClick()
    {
        var machine = GameObject.Find("MachineSelectManager");
        var id = machine.GetComponent<MachineSelectManager>().id;
        Debug.Log("Selected machine ID is " + id.ToString());
        MachineSelectData data = new MachineSelectData(){ id = id };
        StartCoroutine(transCityTrialScene(SE_select, data));
    }
    IEnumerator transCityTrialScene(AudioClip audio, MachineSelectData data)
    {
        GetComponent<AudioSource>().PlayOneShot(audio);
        yield return new WaitForSeconds(audio.length);
        StartCoroutine(SceneTransitioner.Transition("CityTrial", data));
    }
}