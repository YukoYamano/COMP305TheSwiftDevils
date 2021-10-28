using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollectible : MonoBehaviour
{
    [SerializeField] GameObject keyPrompt;
    // Start is called before the first frame update
    void Start()
    {
        keyPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            collision.GetComponent<PlayerController>().GetStone();

        }

        if (collision.CompareTag("Player"))
        {
            keyPrompt.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        keyPrompt.SetActive(false);
    }
}
