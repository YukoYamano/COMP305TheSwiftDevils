using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject topLimit, bottomLimit;
    // [SerializeField] bool hasReachedTop = false, hasReachedBottom = false;
    Vector3 startPosition, topPosition, bottomPosition;

   
    private bool isMoveUp = false;
    private bool isMoveDown = false;
    private bool isMoveToStart  = false;
    
    private  float massOnthePlatform;
    private bool isStoneOnthePlatform = false;

    void Awake()
    {
        startPosition = transform.position;
        topPosition = topLimit.transform.position;
        bottomPosition = bottomLimit.transform.position;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 
    void FixedUpdate()
    {

        if (isStoneOnthePlatform)
        {
            if (isMoveUp)  //if there are stone + player with balloon on the platform => weight =1 =>platform moves to initial position
            {
                Debug.Log($"moveUp  = { isMoveUp}");
                MoveToStart();
                isMoveToStart = false;
                
            }
            else   // in other cases if stone is on the platform, the platform moves down
            {
                Debug.Log($"moveUp  = { isMoveUp}");
                MoveDown();       
                isMoveDown = false;
                
            }
            isStoneOnthePlatform = false;
        }
        else
        {

            if (isMoveUp)
            {
                MoveUp();
                isMoveUp = false;
            }

            if (isMoveDown)
            {
                MoveDown();
                isMoveDown = false;
            }

            if (isMoveToStart)
            {
                MoveToStart();
                isMoveToStart = false;
            }
        }
    }

    // Code for the Moving platform behaviour here

    void OnCollisionStay2D(Collision2D other)
    {
        
          //check if stone is on the platform
     if (other.gameObject.CompareTag("Stone"))
        {
          isStoneOnthePlatform = true;
         }
        else
        {
            isStoneOnthePlatform = false;
        }
        Debug.Log($"stone on the platform  = { isStoneOnthePlatform}");

        //check player weight on the platform
         massOnthePlatform = 1;

         if (other.gameObject.CompareTag("Player"))
        {
            massOnthePlatform = other.gameObject.GetComponent<Rigidbody2D>().mass;
           
        }

        if (massOnthePlatform < 1.0f) //player with balloon
        {
            isMoveUp = true;
        }
        else if (massOnthePlatform > 1.0f)  //player with stone
        {
            isMoveDown = true;
        }
        else if (massOnthePlatform == 1.0f) //player without anything (or have stone & balloon)
        {
            isMoveToStart = true;
        }

    }


    void MoveUp()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(transform.position.x,
                                                             topPosition.y -0.33f,
                                                             transform.position.z),
                                                 speed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(transform.position.x,
                                                             bottomPosition.y - 0.33f,   //0.33f  is adjusment because of offset of platform sprite
                                                             transform.position.z),
                                                 speed * Time.deltaTime);
    }

    void MoveToStart()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(transform.position.x,
                                                             startPosition.y,
                                                             transform.position.z),
                                                 speed * Time.deltaTime);
    }



}








