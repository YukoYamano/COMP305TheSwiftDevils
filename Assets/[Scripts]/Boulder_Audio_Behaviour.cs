using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Audio_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Sound_Manager>().Stop("boulder_drop");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bee"))
        {

            FindObjectOfType<Sound_Manager>().Play("boulder_drop");


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Sound_Manager>().Stop("boulder_drop");
        }

    }
}
