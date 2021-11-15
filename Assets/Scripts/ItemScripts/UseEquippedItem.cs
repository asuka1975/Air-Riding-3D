using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseEquippedItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        Debug.Log("***" + this.gameObject.name + "がUseされる***");
        if(this.gameObject.name == "CannonItemEquipped")
        {
            UseCannonItem();
        }
    }

    void UseCannonItem()
    {
        Debug.Log("CannonItemを使用");
    }
}
