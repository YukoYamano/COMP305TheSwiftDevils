using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask platformLayer;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject balloon;
    [SerializeField] GameObject objSpawner;

    //for testing purposes only
    public bool isGrounded = false; //to see if player is on a surface (for jumping)
    public bool isFacingRight = false; //to see direction player is facing (for flipping sprites)
    public bool isSprinting = false;    //to see if player is sprinting
    public int walkingSpeed = 5;
    public int runningSpeed = 10;
    public int jumpForce = 4;
    public bool isHoldingStone = false;
    public bool isHoldingBalloon = false;

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

    }

    private void Update()
    {
        Jump();
        CheckInput();
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
        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
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


    // E hold stone, Q to hold balloon

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {    //mass + 0.5 if holding stone
            if (isHoldingStone)
            {
                rbody.mass -= 0.5f;
                Instantiate(stone, objSpawner.transform.position, Quaternion.identity);
            }
            else
            {
                rbody.mass += 0.5f;

            }
            isHoldingStone = !isHoldingStone;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {    //mass - 0.5 if holding balloon
            if (isHoldingBalloon)
            {
                rbody.mass += 0.5f;
                Instantiate(balloon, objSpawner.transform.position, Quaternion.identity);

            }
            else
            {
                rbody.mass -= 0.5f;
            }

            isHoldingBalloon = !isHoldingBalloon;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(stone, objSpawner.transform.position, Quaternion.identity);
        }


    }

    //instantiate object stone and balloon if F is pressed




}
