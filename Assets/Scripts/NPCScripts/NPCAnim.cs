using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnim : MonoBehaviour
{
    public NPCState state;
    private Animator anim;
    Transform transform;

    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((state.isMoving)){
            anim.SetBool("isRunning", true);

        }
        else{
            anim.SetBool("isRunning", false);
        }
    }
}
