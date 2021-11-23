using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Audio_Behaviour : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.enabled = false;
        audio.mute = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bee"))
        {
            audio.enabled = true;

        }
        else if(other.gameObject.CompareTag("Seesaw"))
        {
            audio.enabled=false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            audio.mute = false;
        }
    }
}
