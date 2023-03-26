using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public PlayerState state;
    private Animator anim;
    Transform transform;

    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if((state.isGrounded && (Input.GetAxis("Horizontal") != 0))){
            anim.SetBool("isRunning", true);

        }
        else{
            anim.SetBool("isRunning", false);
        }

        if((Input.GetAxis("Horizontal") > 0) && !facingRight){
            Flip();
        }

        if((Input.GetAxis("Horizontal") < 0) && facingRight){
            Flip();
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
