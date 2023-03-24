using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //assign
    public PlayerState state;
    public GameObject feet;
    public GameObject right;
    public GameObject left;
    public Rigidbody2D rb;

    //movement variables
    public float speed = 15f;
    public float jumpSpeed = 17f;
    private float moveInput;
    
    //check variables
    public RaycastHit2D groundCheck;
    public RaycastHit2D wallCheckRight;
    public RaycastHit2D wallCheckLeft;

    //coyote time variables
    public float coyoteTimer;
    public float coyoteLimit = 0.1f;
    
    //jump buffer variables
    public float jumpBufferTimer;
    public float jumpBufferLimit = 0.1f;

    //double jump variable
    public int extraJumpCounter = 1;
    
    //wall jump variable
    public float jumpDirection;
    public float wallJumpTimer = 0.2f;

    void Update()
    {
        //input
        moveInput = Input.GetAxisRaw("Horizontal");
        //input
        
        //idle and moving states
        state.isIdle = state.isGrounded && moveInput == 0;
        state.isMoving = moveInput != 0 && !state.isSticked;
        //idle and moving states

        //horizontal move
        if (!state.isGrappled && !state.isWallJumping)
        {
            if (state.isGrounded || !state.isWalled)
            {
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            }
        }
        //horizontal move
        
        //hook move
        else if(state.isGrappled)
        {
            rb.AddForce(new Vector2(moveInput * 2f,0));
        }
        //hook move

        //ground check
        groundCheck = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f);
        if (groundCheck.collider != null)
        {
            state.isGrounded = groundCheck.collider.CompareTag("Ground");
        }
        
        else
        {
            state.isGrounded = false;
        }
        //ground check
        
        //wall check
        wallCheckRight = Physics2D.Raycast(right.transform.position, Vector2.right, 0.05f);
        wallCheckLeft = Physics2D.Raycast(left.transform.position, Vector2.left, 0.05f);

        if (wallCheckRight.collider != null)
        {
            state.isRightWalled = wallCheckRight.collider.CompareTag("Wall");
        }
        
        else
        {
            state.isRightWalled = false;
        }

        if (wallCheckLeft.collider != null)
        {
            state.isLeftWalled = wallCheckLeft.collider.CompareTag("Wall");
        }

        else
        {
            state.isLeftWalled = false;
        } 
        state.isWalled = state.isLeftWalled || state.isRightWalled;
        //wall check

        //coyote time +
        if (state.isGrounded)
        {
            coyoteTimer = coyoteLimit;
            
            rb.gravityScale = 5f;
            extraJumpCounter = 1;
            state.isJumping = false;
        }
        
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
        //coyote time +

        //jump buffer and wall jump buffer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferTimer = jumpBufferLimit;
        }

        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }
        //jump buffer and wall jump buffer

        //jump
        if (coyoteTimer > 0 && jumpBufferTimer > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            state.isJumping = true;
        }
        //jump

        //variable jump height
        if (!state.isWallJumping)
        {
            if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                coyoteTimer = 0f;
                jumpBufferTimer = 0f;
            }
        }
        //variable jump height

        //double jump
        if (Input.GetKeyDown(KeyCode.Space) && !state.isGrounded && extraJumpCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed*1.25f);
            if (coyoteTimer < 0 && !state.isSticked)
            {
                extraJumpCounter--;
            }
        }
        //double jump
        
        //wall jump
        if (state.isLeftWalled)
        {
            jumpDirection = 1f;
        }

        else if (state.isRightWalled)
        {
            jumpDirection = -1f;
        }

        if (!state.isSticked && state.isWalled && !state.isGrounded)
        { 
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0f;
        }

        state.isSticked = state.isWalled && !state.isGrounded;
        if (state.isSticked)
        {
            wallJumpTimer = 0.2f;
            extraJumpCounter = 1;
            state.isJumping = false;

            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = new Vector2(jumpDirection * jumpSpeed, 0f);
                rb.gravityScale = 5f;
            }

            if (moveInput == -1 * jumpDirection && jumpBufferTimer > 0f)
            {
                state.isWallJumping = true;
                rb.velocity = new Vector2(jumpDirection * jumpSpeed/2f, jumpSpeed);
                rb.gravityScale = -1f;
                state.isSameWallJumping = true;
                
                Invoke(nameof(SameWallJumpFalser), 0.1f);
            }
            
            else if (jumpBufferTimer > 0f)
            {
                state.isWallJumping = true;
                rb.velocity = new Vector2(jumpDirection * jumpSpeed, jumpSpeed);
                rb.gravityScale = 5f;
            }
        }

        wallJumpTimer -= Time.deltaTime;
        if (!Input.GetKey(KeyCode.Space) && wallJumpTimer < 0f && state.isWallJumping)
        {
            state.isWallJumping = false;
        }
        //wall jump
    }

    public void SameWallJumpFalser()
    {
        state.isWallJumping = false;
        state.isSameWallJumping = false;
        rb.gravityScale = 5f;
    }
}