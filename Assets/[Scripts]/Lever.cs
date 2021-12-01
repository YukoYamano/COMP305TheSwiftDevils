using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject instructions;
    public GameObject fan;
    public bool isFanning;
    public Sprite imgOff;
    public Sprite imgOn;
    private float timer = 3;

    BoxCollider2D fanWind;
    SpriteRenderer activeImg;

    // Start is called before the first frame update
    void Start()
    {
        fanWind = fan.GetComponent<BoxCollider2D>();
        isFanning = false;
        activeImg = GetComponent<SpriteRenderer>();
        activeImg.sprite = imgOff;
        timer = 0;
        instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
        StartCountdown();
    }


    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            instructions.SetActive(true);


        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instructions.SetActive(false);
        }
    }

    private void CheckInputs()
    {
        if (instructions.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isFanning)
                {
                    StopFan();
                }
                else
                {
                    StartFan();
                }

            }
        }

    }

    private void StartCountdown()
    {
        if(timer > 0 && isFanning)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= 0 && isFanning)
        {
            StopFan();
        }

    }

    private void StartFan()
    {
        timer = 10;
        isFanning = true;
        fanWind.enabled = true;
        Sound_Manager.PlaySound("fan");
        activeImg.sprite = imgOn;

    }

    private void StopFan()
    {
        timer = 0;
        isFanning = false;
        fanWind.enabled = false;
        Sound_Manager.PlaySound("");
        activeImg.sprite = imgOff;
        StartCountdown();
    }
 

}
