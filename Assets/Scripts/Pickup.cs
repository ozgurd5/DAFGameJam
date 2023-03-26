using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject effect;
    
    private AudioSource pickupSound;
    
    private Renderer rend;
    private CircleCollider2D col;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        pickupSound = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        col = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // spawn the sun button at the first available inventory slot ! 
            

            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0) { // check whether the slot is EMPTY
                    Instantiate(effect, transform.position, Quaternion.identity);
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it


                    pickupSound.Play();
                    rend.enabled = false;
                    col.enabled = false;

                    Destroy(gameObject,pickupSound.clip.length);
                    break;
                }
            }
        }
        
    }
}
