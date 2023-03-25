using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public PlayerState state;
    public AudioSource jumpSound; 
    public AudioSource grappleSound; 

    private bool grappleSoundPlaying;

    // Start is called before the first frame update
    void Start()
    {
        grappleSoundPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (state.isRightWalled || state.isLeftWalled || state.isGrounded || state.isSticked))
        {
            jumpSound.Play();
        }
        if (state.isGrappled && !grappleSoundPlaying){
            grappleSound.Play();
            grappleSoundPlaying = true;
        }
        if(!state.isGrappled){
            grappleSound.Stop();
            grappleSoundPlaying = false;
        }
    }
}
