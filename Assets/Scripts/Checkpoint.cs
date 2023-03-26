using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //assign
    public GameObject feet;

    //variables
    public RaycastHit2D fallGroundCheck;
    public Vector2 lastCheckpoint;
    public bool isFalled;

    private void Update()
    {
        //fall ground check
        fallGroundCheck = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f);
        if (fallGroundCheck.collider != null)
        {
            isFalled = fallGroundCheck.collider.CompareTag("FallGround");
        }
        else
        {
            isFalled = false;
        }
        //fall ground check

        //teleport
        if (isFalled)
        {
            transform.position = lastCheckpoint;
        }
        //teleport
    }

    //checkpoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = other.transform.position;
        }
    }
    //checkpoint
}