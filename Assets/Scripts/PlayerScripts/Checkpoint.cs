using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //assign
    public GameObject playerFeet;
    public List<GameObject> checkpointList = new List<GameObject>();

    //variables
    public RaycastHit2D fallGroundCheck;
    public GameObject lastCheckpoint;
    public bool isFalled;

    private void Update()
    {
        //fall ground check
        fallGroundCheck = Physics2D.Raycast(playerFeet.transform.position, Vector2.down, 0.1f);
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
            transform.position = lastCheckpoint.transform.position;
        }
        //teleport
    }

    //checkpoint
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Checkpoint"))
        {
            if (checkpointList.IndexOf(col.gameObject) > checkpointList.IndexOf(lastCheckpoint))
            {
                lastCheckpoint = col.gameObject;
            }
        }
    }
    //checkpoint
}
