using System;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Assign")]
    public Rigidbody2D rb;
    public GameObject right;
    public GameObject left;
    public NPCState state;
    public float speed;
    public float jumpSpeed;

    [Header("Variables - Don't Touch")]
    public int direction;
    public RaycastHit2D wallCheckRight;
    public RaycastHit2D wallCheckLeft;
    public RaycastHit2D groundCheckRight;
    public RaycastHit2D groundCheckLeft;

    private void Update()
    {
        //direction
        if (Input.GetKeyDown(KeyCode.J)) //go left
        {
            rb.velocity = new Vector2(-1 * speed, 0f);
            direction = -1;
            
            state.isMoving = true;
            state.isIdle = false;
        }
        
        else if (Input.GetKeyDown(KeyCode.L)) //go right
        {
            rb.velocity = new Vector2(speed, 0f);
            direction = 1;
            
            state.isMoving = true;
            state.isIdle = false;
        }
        
        else if (Input.GetKeyDown(KeyCode.K)) //stop
        {
            rb.velocity = new Vector2(0f, 0f);
            
            state.isMoving = false;
            state.isIdle = true;
        }
        //direction

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

        //jump
        if (state.isJumping)
        {
            rb.velocity = new Vector2(direction * speed, jumpSpeed);
            Invoke(nameof(JumpEnder), 0.15f);
        }
        //jump
    }

    public void JumpEnder()
    {
        Debug.Log("yara");
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        state.isJumping = false;
    }
}
