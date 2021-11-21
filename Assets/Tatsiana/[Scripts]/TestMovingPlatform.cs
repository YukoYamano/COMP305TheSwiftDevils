using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject topLimit, bottomLimit;

    Vector3 startPosition, topPosition, bottomPosition;


    private bool isMoveUp = false;
    private bool isMoveDown = false;
    private bool isMoveToStart = false;

    private float massOnthePlatform = 1.0f;
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
                Debug.Log($"Stone on platform. moveUp  = { isMoveUp}");
                MoveToStart();
               

            }
            else   // in other cases if stone is on the platform, the platform moves down
            {
                Debug.Log( $"Stone on platform. moveUp  = { isMoveUp}");
                MoveDown();
               

            }
            isStoneOnthePlatform = false;
         collisions.Remove("Stone");
        
        }
        else
        {
            Debug.Log($"No stone on platform");

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
    private List<string> collisions = new List<string>();
    
    void OnCollisionStay2D(Collision2D other)
    {
          collisions.Add(other.gameObject.tag);

        if (collisions.Contains("Player") && collisions.Contains("Stone"))
        {
            isStoneOnthePlatform = true;
            massOnthePlatform = 1.5f;

        }
        else
        {
            
            //check if stone is on the platform
            if (collisions.Contains("Stone"))   
            {
                Debug.Log($"stone");
                isStoneOnthePlatform = true;
            }
            else
            {
                Debug.Log($"no stone");
                isStoneOnthePlatform = false;
            }

            //check if player is on the platform
            if (collisions.Contains("Player"))   
            {
                massOnthePlatform = other.gameObject.GetComponent<Rigidbody2D>().mass;
            }   
            else
            {
                massOnthePlatform = 1;
            }
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

    public void OnCollisionExit2D(Collision2D other)
    {
        collisions.Remove(other.gameObject.tag);
       
    }

        void MoveUp()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(transform.position.x,
                                                             topPosition.y - 0.33f,
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








