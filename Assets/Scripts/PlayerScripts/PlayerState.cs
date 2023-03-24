using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //assign
    public PlayerControl playerControl;
    public GrappleHook grappleHook;
    
    //movement states
    public bool isFacingRight = true;
    public bool isFacingLeft;
    public bool isMoving;
    public bool isIdle;
    public bool isJumping;
    public bool isGrounded;
    
    //long jump states
    public bool isLongJumping;
    
    //wall jump states
    public bool isWalled;
    public bool isRightWalled;
    public bool isLeftWalled;
    public bool isSticked;
    public bool isSameWallJumping;
    public bool isWallJumping;
    
    //hook states
    public bool isPulled;
    public bool isGrappled;
}
