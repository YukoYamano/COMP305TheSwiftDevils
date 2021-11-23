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
    public AudioSource audio;

    BoxCollider2D fanWind;
    SpriteRenderer activeImg;

    // Start is called before the first frame update
    void Start()
    {
        fanWind = fan.GetComponent<BoxCollider2D>();
        isFanning = false;
        activeImg = GetComponent<SpriteRenderer>();
        instructions.SetActive(false);
        audio = GetComponent<AudioSource>();
        audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
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
                isFanning = !isFanning;
                fanWind.enabled = isFanning;

                //for changing sprites
                if (isFanning)
                {
                    audio.enabled = true;
                    activeImg.sprite = imgOn;
                }
                else
                {
                    audio.enabled = false;
                    activeImg.sprite = imgOff;
                }

            }
        }

    }

}
