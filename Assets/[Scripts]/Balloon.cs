using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] GameObject balloon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (collision.GetComponent<PlayerController>().isHoldingBalloon == false)
            {
                collision.GetComponent<PlayerController>().GetBalloon();
                Destroy(balloon);
            }

        }
    }
}