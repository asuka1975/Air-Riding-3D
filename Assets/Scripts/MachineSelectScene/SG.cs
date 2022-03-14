using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

class MachineSelectData {
    public int id;
}
public class SG : MonoBehaviour
{
    public AudioClip SE_battleStart;
    public AudioMixer mixer;
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
        StartCoroutine(transCityTrialScene(SE_battleStart, data));
    }
    IEnumerator transCityTrialScene(AudioClip audio, MachineSelectData data)
    {
        GameObject.Find("SEManager").GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        yield return new WaitForSeconds(0.3f);
        mixer.SetFloat("BGM", -20f);
        yield return new WaitForSeconds(audio.length - 1.0f);
        mixer.SetFloat("BGM", 0.0f);
        StartCoroutine(SceneTransitioner.Transition("CityTrial", data));
    }
}