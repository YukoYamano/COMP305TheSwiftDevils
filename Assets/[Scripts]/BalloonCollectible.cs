using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollectible : MonoBehaviour
{
    [SerializeField] GameObject keyPrompt;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        keyPrompt.SetActive(false);
        audio = GetComponent<AudioSource>();
        audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            audio.enabled = true;
            collision.GetComponent<PlayerController>().GetBalloon();

        }

        if (collision.CompareTag("Player"))
        {
            keyPrompt.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        keyPrompt.SetActive(false);
        audio.enabled = false;
    }
}
