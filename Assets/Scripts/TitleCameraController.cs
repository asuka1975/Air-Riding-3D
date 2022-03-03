using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraController : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0.2f, 0), Space.World);
    }
}
