using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Assign")]
    public GameObject right;
    public GameObject left;
    public NPCState state;
    public float speed;
    public float jumpSpeed;

    [Header("Variables - Don't Touch")]
    public static Rigidbody2D[] selectedNPC = new Rigidbody2D[1];
    public Rigidbody2D rb;
    public Collider2D col;
    public int direction;
    public bool canMoveRight;
    public bool canMoveLeft;
    public RaycastHit2D rightCheck;
    public RaycastHit2D leftCheck;
    public RaycastHit2D rightCheckDown;
    public RaycastHit2D leftCheckDown;

    private void OnMouseDown()
    {
        selectedNPC[0] = rb;
    }

    private void Update()
    {
        //controls
        if (rb == selectedNPC[0])
        {
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
        rightCheckDown = Physics2D.Raycast(right.transform.position, Vector2.down, 2.55f);
        leftCheckDown = Physics2D.Raycast(left.transform.position, Vector2.down, 2.55f);
        
        if (rightCheckDown.collider != null)
        {
            canMoveRight = rightCheckDown.collider.CompareTag("Ground") || rightCheckDown.collider.CompareTag("Checkpoint");
        }
        else
        {
            canMoveRight = false;
        }
        if (leftCheckDown.collider != null)
        {
            canMoveLeft = leftCheckDown.collider.CompareTag("Ground") || leftCheckDown.collider.CompareTag("Checkpoint");
        }
        else
        {
            canMoveLeft = false;
        }
        //ground check
        
        //right-left check
        rightCheck = Physics2D.Raycast(right.transform.position, Vector2.right, 0.05f);
        leftCheck = Physics2D.Raycast(left.transform.position, Vector2.left, 0.05f);
    
        if (rightCheck.collider != null)
        {
            state.isJumping = rightCheck.collider.CompareTag("Ground");
            
            if (rightCheck.collider.CompareTag("Player") || rightCheck.collider.CompareTag("NPC"))
            {
                Physics2D.IgnoreCollision(rightCheck.collider, col);
                canMoveRight = false;
            }
        }
        if (leftCheck.collider != null)
        {
            state.isJumping = leftCheck.collider.CompareTag("Ground");

            if (leftCheck.collider.CompareTag("Player") || leftCheck.collider.CompareTag("NPC"))
            {
                Physics2D.IgnoreCollision(leftCheck.collider, col);
                canMoveLeft = false;
            }
        }
        //right-left  check
    }

    public void JumpEnder()
    {
        selectedNPC[0].velocity = new Vector2(selectedNPC[0].velocity.x, 0f);
        state.isJumping = false;
    }
}
