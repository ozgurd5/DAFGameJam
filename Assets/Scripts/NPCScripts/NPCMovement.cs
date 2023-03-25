using System;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Assign")]
    public GameObject right;
    public GameObject left;
    public GameObject rightGround;
    public GameObject leftGround;
    public NPCState state;
    public float speed;
    public float jumpSpeed;

    [Header("Variables - Don't Touch")]
    public static Rigidbody2D[] selectedNPC = new Rigidbody2D[1];
    public Rigidbody2D rb;
    public int direction;
    public bool canMoveRight;
    public bool canMoveLeft;
    public RaycastHit2D wallCheckRight;
    public RaycastHit2D wallCheckLeft;
    public RaycastHit2D groundCheckRight;
    public RaycastHit2D groundCheckLeft;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        selectedNPC[0] = rb;
    }

    private void Update()
    {
        if (rb == selectedNPC[0])
        {
            //controls
            if (Input.GetKeyDown(KeyCode.J) && canMoveLeft) //go left
            {
                direction = -1;
            
                state.isMoving = true;
                state.isIdle = false;
            }
            else if (Input.GetKeyDown(KeyCode.L) && canMoveRight) //go right
            {
                direction = 1;
            
                state.isMoving = true;
                state.isIdle = false;
            }
            else if (Input.GetKeyDown(KeyCode.K)) //stop
            {
                state.isMoving = false;
                state.isIdle = true;
            }
            //controls

            //movement
            if (direction == 1 && !canMoveRight)
            {
                state.isMoving = false;
                state.isIdle = true;
            }
            if (direction == -1 && !canMoveLeft)
            {
                state.isMoving = false;
                state.isIdle = true;
            }
            //movement
            
            //movement
            if (state.isMoving)
            {
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            }

            if (state.isIdle)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            //movement
            
            //jump
            if (state.isJumping)
            {
                rb.velocity = new Vector2(direction * speed, jumpSpeed);
                Invoke(nameof(JumpEnder), 0.15f);
            }
            //jump

            //ground check
            groundCheckRight = Physics2D.Raycast(right.transform.position, Vector2.down, 2.55f);
            groundCheckLeft = Physics2D.Raycast(left.transform.position, Vector2.down, 2.55f);
            
            if (groundCheckRight.collider != null)
            {
                canMoveRight = groundCheckRight.collider.CompareTag("Ground");
            }
            else
            {
                canMoveRight = false;
            }
            if (groundCheckLeft.collider != null)
            {
                canMoveLeft = groundCheckLeft.collider.CompareTag("Ground");
            }
            else
            {
                canMoveLeft = false;
            }
            //ground check
            
            //wall check
            wallCheckRight = Physics2D.Raycast(right.transform.position, Vector2.right, 0.05f);
            wallCheckLeft = Physics2D.Raycast(left.transform.position, Vector2.left, 0.05f);
        
            if (wallCheckRight.collider != null)
            {
                state.isJumping = wallCheckRight.collider.CompareTag("Ground");
            }
            if (wallCheckLeft.collider != null)
            {
                state.isJumping = wallCheckLeft.collider.CompareTag("Ground");
            }
            //wall check
        }
    }

    public void JumpEnder()
    {
        selectedNPC[0].velocity = new Vector2(selectedNPC[0].velocity.x, 0f);
        state.isJumping = false;
    }
}
