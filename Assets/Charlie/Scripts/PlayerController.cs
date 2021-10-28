using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] LayerMask platformLayer;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject balloon;
    [SerializeField] GameObject groundCheck;
    [SerializeField] GameObject balloonSprite;
    [SerializeField] GameObject stoneSprite;

    //for testing purposes only
    public bool isGrounded = false; //to see if player is on a surface (for jumping)
    public bool onPlatform = false; //flag to see if player is on a platform
    public bool isFacingRight = false; //to see direction player is facing (for flipping sprites)
    public float moveSpeed = 5f; //movespeed
    public float jumpForce = 3.5f; //regular jump
    public const float massChange = 0.25f; //mass change when picking up stone or balloon
    public bool isHoldingStone = false; //true when holding stone
    public bool isHoldingBalloon = false; //true when holding balloon
    public float fallMultiplier = 3.0f; //higher grav when falling,
    public float lowJumpMultiplier = 2.5f; //grav multiplier 


    //additional distance to cast
    float extra = 0.1f;

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
    }

    private void Update()
    {
        CheckGrounded();
        Jump();
        CheckInput();
        UpdateSprites();



    }

    //Lateral Movement function
    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        animator.SetFloat("Walking", Mathf.Abs(x));

        //moves the character left and right using add force
        rbody.AddForce(new Vector3(x * moveSpeed, 0, 0));


        //for turning
        if ((x < 0 && isFacingRight == false) || (x > 0 && isFacingRight == true))
        {
            Turn();
        }


    }

    void Turn()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
    }


    void Jump()
    {
        //Adding force to obj for jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (rbody.velocity.y < 0) //when falling, applies a grav multiplier in order to fall faster
        {
            rbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rbody.velocity.y > 0 && Input.GetButton("Jump") == false) //if rising, but Jump key is released 'early' (before apex of jump), apply a slightly lower grav muliplier
        {
            rbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }




    void CheckGrounded()
    {
        //
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, extra, platformLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }


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

    }


    // E hold stone, Q to hold balloon, press respective button to 'drop' the item

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.F))
        {
            DropStone();

        }
        if (Input.GetKey(KeyCode.Q))
        {
            DropBalloon();
        }

    }

    public void GetBalloon()
    {
        if (!isHoldingBalloon)
        {
            isHoldingBalloon = true;
            rbody.mass -= massChange;
        }
    }

    public void GetStone()
    {
        if (!isHoldingStone)
        {
            isHoldingStone = true;
            rbody.mass += massChange;
        }

    }

    private void DropBalloon()
    {
        if (isHoldingBalloon)
        {

            rbody.mass += massChange;
            Instantiate(balloon, balloonSprite.transform.position, Quaternion.identity);
            isHoldingBalloon = false;

        }
    }

    private void DropStone()
    {
        if (isHoldingStone)
        {
            rbody.mass -= massChange;
            Instantiate(stone, stoneSprite.transform.position, Quaternion.identity);
            isHoldingStone = false;
        }
    }

    private void UpdateSprites()
    {
        if (isHoldingBalloon)
        {
            balloonSprite.SetActive(true);
        }
        else if(!isHoldingBalloon)
        {
            balloonSprite.SetActive(false);
        }

        if (isHoldingStone)
        {
            stoneSprite.SetActive(true);
        }
        else if(!isHoldingStone)
        {
            stoneSprite.SetActive(false);
        }
    }

}
