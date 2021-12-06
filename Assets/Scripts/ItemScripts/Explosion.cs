using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionScale = 10.0f;
    public int LifeSpan = 50;

    public float Damage = 10f;

    private int life = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 size;
        size = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale =
            new Vector3(size.x * ExplosionScale, size.y * ExplosionScale, size.z * ExplosionScale);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        life += 1;
        
        if (life > LifeSpan)
        {
           Destroy(this.gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MachineBehavior>().HP -= Damage;
        }
    }
}
