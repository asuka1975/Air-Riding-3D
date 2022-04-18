using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class HoverSE : MonoBehaviour
{
    public AudioClip SE_hover;
    public void PointerEnter()
    {
        GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(SE_hover, 0.1f); // SE (hover)
    }
}