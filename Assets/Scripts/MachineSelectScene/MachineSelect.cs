using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MachineSelect : MonoBehaviour
{
    public int id;
    public AudioMixer mixer;
    public AudioClip SE_click_button;
    public AudioClip SE_hover_button;
    public void OnClick()
    {
        GameObject.Find("SEManager").GetComponent<AudioSource>().PlayOneShot(SE_click_button);
        var machine = GameObject.Find("MachineSelectManager");
        machine.GetComponent<MachineSelectManager>().id = id;
        var str = "Selected machine ID is " + machine.GetComponent<MachineSelectManager>().id;
        Debug.Log(str);
        ButtonManager.SetInteractive("Button_StartGame", true);
    }
    public void PointerEnter()
    {
        StartCoroutine(
            PlaySE(GameObject.Find("SEManager").GetComponent<AudioSource>(), "SE", SE_hover_button, -10f)
        );        
    }
    IEnumerator PlaySE(AudioSource source, String type, AudioClip clip, float volume)
    {
        mixer.SetFloat(type, volume);
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        mixer.SetFloat(type, 0.0f);
    }
}