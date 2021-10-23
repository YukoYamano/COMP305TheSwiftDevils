using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    [SerializeField] float offsetTop = 0, offsetBottom = 0, speed = 1;
   // [SerializeField] bool hasReachedTop = false, hasReachedBottom = false;
    Vector3 startPosition = Vector3.zero;

    private Rigidbody2D rbody;
    private bool isMoveUp = false;
    private bool isMoveDown = false;
    private bool isMoveToStart  = false;
    
    private float massOnthePlatform;
    private float  stoneOnthePlatform;

    void Awake()
    {
        startPosition = transform.position;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 
    void FixedUpdate()
    {
        if (isMoveUp)
        {   
            Move(offsetTop);
            isMoveUp = false;
        }

        if (isMoveDown)
        {
             Move(offsetBottom);
            isMoveDown = false;
        }

        if (isMoveToStart)
        {
            MoveToStart();
            isMoveToStart = false;
        }
    }

    // Code for the Moving platform behaviour here
    void OnCollisionStay2D(Collision2D other) 
    {
        massOnthePlatform = 0;

        if (other.gameObject.CompareTag("Stone"))
            {
            stoneOnthePlatform = 1.5f;
            }
            else
            {
            stoneOnthePlatform = 0f; 
            }
        massOnthePlatform = stoneOnthePlatform;
      //  Debug.Log($"massOnthePlatform = stoneOnthePlatform = {massOnthePlatform}");
        
        if (other.gameObject.CompareTag("Player"))
        {
            massOnthePlatform = stoneOnthePlatform + other.gameObject.GetComponent<Rigidbody2D>().mass;
       //     Debug.Log($"mass on the platform with player = { massOnthePlatform}");
        }
        else
        {
            massOnthePlatform = stoneOnthePlatform;
        }
            
         if(massOnthePlatform < 1.0f)
        { 
          isMoveUp = true; 
        }
        else if (massOnthePlatform > 1.0f)
        { 
         isMoveDown = true;
        }
        else if (massOnthePlatform == 1.0f)
        {
            isMoveToStart  = true;
        }
    }

    void Move(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(transform.position.x,
                                                             startPosition.y + offset,
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


    //CODE FOR THE STONE ON THE PLATFORM
    //[SerializeField] float offsetTop = 0, offsetBottom = 0, speed = 1;
    //// [SerializeField] bool hasReachedTop = false, hasReachedBottom = false;
    //Vector3 startPosition = Vector3.zero;

    //private Rigidbody2D rbody;
    //private bool isMoveUp = false;
    //private bool isMoveDown = false;
    //private bool isMoveToStart = false;
    //void Awake()
    //{
    //    startPosition = transform.position;
    //}

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// 
    //void FixedUpdate()
    //{
    //    if (isMoveUp)
    //    {
    //        Move(offsetTop);
    //        isMoveUp = false;
    //    }

    //    if (isMoveDown)
    //    {
    //        Move(offsetBottom);
    //        isMoveDown = false;
    //    }

    //    if (isMoveToStart)
    //    {
    //        MoveToStart();
    //        isMoveToStart = false;
    //    }
    //}

    //// Code for the Moving platform behaviour here
    //void OnCollisionStay2D(Collision2D other)
    //{
    //    Debug.Log("collision");

    //    if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass < 1.0)
    //    {
    //        Debug.Log("if collision");
    //        isMoveUp = true;
    //    }
    //    else if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass > 1.0)
    //    {
    //        Debug.Log("else collision");
    //        isMoveDown = true;
    //    }
    //    else if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass == 1.0)
    //    {
    //        Debug.Log("mass=1");
    //        isMoveToStart = true;
    //    }
    //}

    //void Move(float offset)
    //{
    //    transform.position = Vector3.MoveTowards(transform.position,
    //                                             new Vector3(transform.position.x,
    //                                                         startPosition.y + offset,
    //                                                         transform.position.z),
    //                                             speed * Time.deltaTime);
    //}

    //void MoveToStart()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position,
    //                                             new Vector3(transform.position.x,
    //                                                         startPosition.y,
    //                                                         transform.position.z),
    //                                             speed * Time.deltaTime);
    //}




}








