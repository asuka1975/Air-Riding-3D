using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip SE_explosion;
    private AudioSource audio_source;
    public float ExplosionScale = 10.0f;
    public float Damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 size;
        size = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale =
            new Vector3(size.x * ExplosionScale, size.y * ExplosionScale, size.z * ExplosionScale);
        // SE
        audio_source = GetComponent<AudioSource>();
        audio_source.PlayOneShot(SE_explosion, 1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (!audio_source.isPlaying)
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
