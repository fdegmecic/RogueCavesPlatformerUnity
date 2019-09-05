using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    AudioManager audioManager;
    [SerializeField]
    GameObject switchOn;
    SpriteRenderer rend;
    CircleCollider2D cc;
    bool hasBeenTriggered;
    public bool isOn = false;

    void Start()
    {
        audioManager = AudioManager.instance;
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        cc = this.gameObject.GetComponent<CircleCollider2D>();

        gameObject.GetComponent<SpriteRenderer>().sprite = switchOn.GetComponent<SpriteRenderer>().sprite;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (hasBeenTriggered)
            return;
        if (collider.gameObject.tag == "Player")
        {
            hasBeenTriggered = true;


            rend.enabled = !rend.enabled;
        
            cc.enabled = false;

            isOn = true;
            audioManager.playSound("SwitchSound");
        }
    }

}
