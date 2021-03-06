using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] GameObject balloon;
    [SerializeField] private bool isBlowing;
    [SerializeField] private bool blowingRight;

    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponentInParent<Rigidbody2D>();
        isBlowing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBlowing)
        {
            MoveBalloon();
        }
        else
        {
            rbody.velocity = new Vector2(0, 1);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (collision.GetComponent<PlayerController>().isHoldingBalloon == false)
            {
                FindObjectOfType<Sound_Manager>().Play("pickUpItem");
                collision.GetComponent<PlayerController>().GetBalloon();
                Destroy(balloon);
            }

        }
    }

    private void MoveBalloon()
    {
        //if (isBlowing)
        //{
            if (blowingRight)
            {
                rbody.velocity = new Vector2(1, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(-1, rbody.velocity.y);
            }
        //}
        //
    }

    public void setStatus(bool blowing, bool blowingDirection)
    {
        isBlowing = blowing;
        blowingRight = blowingDirection;
    }


}
