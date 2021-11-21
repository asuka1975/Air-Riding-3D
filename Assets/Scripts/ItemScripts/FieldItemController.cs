using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItemController : MonoBehaviour
{
    public float survivalTimeCount = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        survivalTimeCount -= Time.deltaTime;
        if (survivalTimeCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 1.0f, 0), Space.World);
    }
}
