using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] GameObject stone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Code for stone behaviour here
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (collision.GetComponent<PlayerController>().isHoldingStone == false)
            {
                collision.GetComponent<PlayerController>().GetStone();
                Destroy(stone);
            }

        }
    }



}
