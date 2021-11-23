using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Trigger : MonoBehaviour
{
    //[Tooltip("This accesses the Player Controller Script, Place Character here.")]
    //public PlayerController playerController;

    [Tooltip("This accesses the Water Base Tilemap Collider 2D, Drag and drop the Tilemap Collider 2D here")]
    public Collider2D waterBase;

    //private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        waterBase = GetComponent<Collider2D>();
        waterBase.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        //Debug.Log("Collision Detected");
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass > 1)
        {
            Debug.Log("If statement passed");
            waterBase.isTrigger = true;
            Debug.Log("Trigger");


        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass <= 1)
        {
 
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -2.5f;
            //Debug.Log("Rise");
        }
    }


}
