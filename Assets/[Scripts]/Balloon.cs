using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] GameObject balloon;
    public int speed = 4;
    private bool isBlowing;
    private bool blowingRight;

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
        MoveBalloon();
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

    private void MoveBalloon()
    {
        if (isBlowing)
        {
            if (blowingRight)
            {
                rbody.velocity = new Vector2(1 * speed, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(0, rbody.velocity.y);
            }
        }
        else
        {
            rbody.velocity = new Vector2(0, 1);
        }
    }

    public void setStatus(bool blowing, bool blowingDirection)
    {
        isBlowing = blowing;
        blowingRight = blowingDirection;
    }


}
