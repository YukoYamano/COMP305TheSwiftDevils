using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Controller : MonoBehaviour
{
    public Collider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Sound_Manager>().Play("bee");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Sound_Manager>().Stop("bee");
        }
    }
}
