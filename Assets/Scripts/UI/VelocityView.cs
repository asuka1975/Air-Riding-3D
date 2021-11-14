using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityView : MonoBehaviour
{
    private Text _velocityLabel;
    private Rigidbody _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _velocityLabel = GetComponent<Text>();
        _player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocityLabel.text = $"{_player.velocity.magnitude:F2}";
    }
}
