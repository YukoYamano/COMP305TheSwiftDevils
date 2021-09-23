using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    public Text tutorial;
    public Text controls1;
    public Text controls2;
    public Text controls3;
    public Text enter;
    public GameObject panel;

    bool check = false;
    bool check2 = false;
    int count = 0;   
    // Start is called before the first frame update
    void Start()
    {
        tutorial.enabled = false;

        panel.SetActive(false);
        controls1.enabled = false;
        enter.enabled = false;
        controls2.enabled = false;
        controls3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorial.enabled = true;



        }


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetAxis("Fire1") > 0)
        {
                //Debug.Log("Panel");
                panel.SetActive(true);
                controls1.enabled = true;
                enter.enabled = true;
                check = true;

            }
            if (check==true && Input.GetAxis("Submit") > 0 )
            {
                controls1.enabled = false;
                controls2.enabled = true;
                check2 = true;
            }
           

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tutorial.enabled = false;

    }


}
