using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Audio_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Spike"))
        {
            FindObjectOfType<Sound_Manager>().Play("balloonPop");
        }
        
    }
}
