using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //assign
    public GameObject feet;

    //variables
    public RaycastHit2D fallGroundCheck;
    public Vector2 lastCheckpoint;
    public bool isFalled;
    public Vector2 capSize;
    public Vector2 capOffset;
    public float radius;
    public LayerMask spikeLayer;


    private void Update()
    {
        //fall ground check
        fallGroundCheck = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f);
       // RaycastHit2D[] hits = Physics2D.CircleCastAll(gameObject.transform.position, radius, Vector2.zero, 0f, spikeLayer);
       // foreach (RaycastHit2D fallGround in hits)
       //{

            //     Debug.Log(" " + fallGround);
            //     if (fallGround.collider != null)
            //        isFalled = fallGround.collider.CompareTag("FallGround");
        //else
        //        isFalled = false;
        // }
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(feet.transform.position, lastCheckpoint);
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(gameObject.transform.position, radius);
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