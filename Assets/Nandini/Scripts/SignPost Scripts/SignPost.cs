using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    public Text prompt;
    public Text instructions;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        prompt.enabled = false;

        panel.SetActive(false);
        instructions.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prompt.enabled = true;



        }


    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetAxis("Fire1")>0)
            {
                Debug.Log("Panel");
                panel.SetActive(true);                
                instructions.enabled = true;
                
            }
            //if (Input.GetAxis("Fire1") > 0)
            //{
            //    controls1.enabled = false;
            //    enter.enabled = false;
            //    panel.SetActive(false);

            //}



        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        prompt.enabled = false;
        if(other.gameObject.CompareTag("Player"))
        {
            instructions.enabled = false;
            panel.SetActive(false);
        }
           

    }


}
