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


    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }

    void FixedUpdate()
    { 

    }

    private void Update()
    {
        UpdateAnimation();
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            collision.gameObject.GetComponentInChildren<Balloon>().setStatus(true, blowingRight);

            applyingForce = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Balloon"))
        {
            collision.gameObject.GetComponentInChildren<Balloon>().setStatus(false, blowingRight);

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

//    private void ApplyForce(Rigidbody2D rbody)
//    {
//        if (blowingRight)
//        {
//            rbody.velocity = new Vector2(1 * speed, rbody.velocity.y);
//        }
//        else
//        {
//            rbody.velocity = new Vector2(-1 * speed, rbody.velocity.y);
//        }
//    }

//    private void StopApplyForce(Rigidbody2D rbody)
//    {
//        rbody.velocity = new Vector2(0 * speed, rbody.velocity.y);
//    }

}


