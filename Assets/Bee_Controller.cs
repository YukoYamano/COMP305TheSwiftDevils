using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Controller : MonoBehaviour
{
    public Collider2D Collider;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<Collider2D>();
        audio = GetComponent<AudioSource>();
        audio.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            audio.volume = 0.7f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audio.volume = 0f;
        }
    }
}
