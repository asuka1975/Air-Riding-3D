using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material obj = this.GetComponent<Renderer>().material;
        obj.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
    }
}
