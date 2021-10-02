using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    //[Tooltip("This accesses the Player Controller Script, Place Character here.")]
    public PlayerController playerController;
    //[Tooltip("This accesses the Moving platform rigidbody 2D, Drag and drop the  here")]
    //public Rigidbody2D platformRbody ;
    public Collider2D movingPlatform;

    //    waterBase.isTrigger = false;
    private Rigidbody2D rbody;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
   
    // Code for stone behaviour here
    void OnCollisionStay2D(Collision2D other)
        {
        Debug.Log("collision");

        if (other.gameObject.CompareTag("Player")&& other.gameObject.GetComponent<Rigidbody2D>().mass == 1.5)
            {                  //platformRbody = GetComponent<Rigidbody2D>();
                               // GetComponent<Collider2D>().isTrigger = true;
                              Debug.Log("if collision");
          rbody.transform.position = new Vector3(-5.5f, 2.0f, 0);
            
                        }
            else if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass == 0.5)
            { Debug.Log("else collision");
                rbody.transform.position = new Vector3(-5.5f, transform.position.y + 2, 0);
            
        }
        Debug.Log("nothing after collision");

        //rbody.velocity = new Vector2(0, 0);

    }
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.CompareTag("MovingPlatform"))
    //    {       
    //            Debug.Log("Rise");
    //            other.gameObject.GetComponent<Rigidbody2D>().transform.position = new Vector3(transform.position.x, transform.position.y + 2, 0);
    //    }       
    //}       
}
// Code for moving platform behaviour here


// water puzzle
//[Tooltip("This accesses the Player Controller Script, Place Character here.")]
//public PlayerController playerController;

//[Tooltip("This accesses the Water Base Tilemap Collider 2D, Drag and drop the Tilemap Collider 2D here")]
//public Collider2D waterBase;

//private GameObject player;
//// Start is called before the first frame update
//void Start()
//{
//    waterBase = GetComponent<Collider2D>();
//    waterBase.isTrigger = false;
//}

//// Update is called once per frame
//void Update()
//{
//    if (playerController.isHoldingStone == true)
//    {
//        waterBase.isTrigger = true;
//        //Debug.Log("Trigger");
//    }

//}

//private void OnTriggerStay2D(Collider2D other)
//{
//    if (other.CompareTag("Player") && playerController.isHoldingStone == false)
//    {
//        player = other.gameObject;
//        player.GetComponent<Rigidbody2D>().gravityScale = -0.1f;
//        //Debug.Log("Rise");
//    }
//}


//}
