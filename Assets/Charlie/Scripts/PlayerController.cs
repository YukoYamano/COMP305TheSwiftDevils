using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask platformLayer;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject balloon;
    [SerializeField] GameObject objSpawner;
    [SerializeField] GameObject balloonSprite;
    [SerializeField] GameObject stoneSprite;

    //for testing purposes only
    public bool isGrounded = false; //to see if player is on a surface (for jumping)
    public bool isFacingRight = false; //to see direction player is facing (for flipping sprites)
    public bool isSprinting = false;    //to see if player is sprinting
    public float walkingSpeed = 5f;
    public float runningSpeed = 10f;
    public float jumpForce = 3.5f;
    public bool isHoldingStone = false;
    public bool isHoldingBalloon = false;


    //additional distance to cast
    float extra = 0.01f;

    private Rigidbody2D rbody;
    private CapsuleCollider2D cCol;
    private Animator animator;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        cCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

    }

    // Fixed Update is called because physics calculations are required
    void FixedUpdate()
    {
        Move();
        _ = CheckGrounded();



    }

    private void Update()
    {
        Jump();
        CheckInput();
        UpdateSprites();


    }

    //Lateral Movement function
    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        animator.SetFloat("Walking", Mathf.Abs(x));

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

        //for turning
        if ((x < 0 && isFacingRight == false)||(x > 0 && isFacingRight == true))
        {
            Turn();
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

    void Turn()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
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
        //Check if player is on the Moving Platform
        if (raycastHit.collider != null && raycastHit.collider.tag == "MovingPlatform")
        {
            transform.parent = raycastHit.transform;
        }
        else
        {
            transform.parent = null;
        }


        if (raycastHit)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
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
                Instantiate(stone, stoneSprite.transform.position, Quaternion.identity);
                stoneSprite.SetActive(true);
            }
            else
            {
                rbody.mass += 0.5f;
                stoneSprite.SetActive(false);

            }
            isHoldingStone = !isHoldingStone;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {    //mass - 0.5 if holding balloon
            if (isHoldingBalloon)
            {
                rbody.mass += 0.5f;
                Instantiate(balloon, balloonSprite.transform.position, Quaternion.identity);


            }
            else
            {
                rbody.mass -= 0.5f;

            }

            isHoldingBalloon = !isHoldingBalloon;
        }


    }

    private void UpdateSprites()
    {
        if (isHoldingBalloon)
        {
            balloonSprite.SetActive(true);
        }
        else
        {
            balloonSprite.SetActive(false);
        }

        if (isHoldingStone)
        {
            stoneSprite.SetActive(true);
        }
        else
        {
            stoneSprite.SetActive(false);
        }
    }

}
