using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    //Troubleshooting variables
    [Tooltip("Returns true when applying a force to detected object, DO NOT TOUCH")]
    [SerializeField] private bool applyingForce = false;

    //public variables
    [Tooltip("Set true if fan is blowing towards the right -->")]
    public bool blowingRight = true;
    [Tooltip("The amount of lateral force applied to balloon")]
    public float windForce = 3.0f;



    private Rigidbody2D balloonRbody;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        //switches the direction of force being applied
        if(blowingRight)
        {
            windForce *= 1;
        }
        else
        {
            windForce *= -1;
        }
        
    }

    void FixedUpdate()
    {
        if (applyingForce)
        {
            AddForce(balloonRbody);
        }

    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void AddForce(Rigidbody2D rbodyOther)
    {
        rbodyOther.AddForce(new Vector2(1 * windForce, 0));
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            balloonRbody = collision.gameObject.GetComponent<Rigidbody2D>();
            applyingForce = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            applyingForce = false;
        }
    }

    //update animations depending on if boxcollider is active or not
    public void UpdateAnimation()
    {
        if (GetComponent<BoxCollider2D>().enabled)
        {
            anim.SetBool("isBlowing", true);
        }
        else { anim.SetBool("isBlowing", false); }
    }

}


