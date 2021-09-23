using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask platformLayer;

    //for testing purposes only
    public bool isGrounded = false; //to see if player is on a surface (for jumping)
    public bool isFacingRight = false; //to see direction player is facing (for flipping sprites)
    public bool isSprinting = false;    //to see if player is sprinting
    public int walkingSpeed = 5;
    public int runningSpeed = 10;
    public int jumpForce = 3;

    //
    float extra = 0.01f;

    private Rigidbody2D rbody;
    private CapsuleCollider2D cCol;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        cCol = GetComponent<CapsuleCollider2D>();

    }

    // Fixed Update is called because physics calculations are required
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    //Lateral Movement function
    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        //checks if the Shift key is being held down
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }


        if (isSprinting)
        {
            rbody.AddForce(new Vector3(x * runningSpeed, 0, 0));
        }
        else
        {
            rbody.AddForce(new Vector3(x * walkingSpeed, 0, 0));
        }

    }

    void Jump()
    {
        
        //Adding force to obj for jump
        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded() == true)
        {
            rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    bool CheckGrounded()
    {
        //using a box collider to check means that I can jump repeatedly if next to a wall...
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            cCol.bounds.center,
            cCol.bounds.size,
            0f,
            Vector2.down,
            extra, platformLayer);

        if(raycastHit) 
        { 
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        return isGrounded;
    }




}
