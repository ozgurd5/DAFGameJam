using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPickup : MonoBehaviour {
    private TMPro.TextMeshProUGUI item;
    private int itemCount;
    public GameObject effect;
    private AudioSource pickupSound;
    
    private Renderer rend;
    private CircleCollider2D col;

    private void Start()
    {
        pickupSound = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        col = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            
            if(this.CompareTag("Health")){
                Instantiate(effect, transform.position, Quaternion.identity);
                item = (GameObject.FindGameObjectWithTag("HealthCount").GetComponent<TMPro.TextMeshProUGUI>());
                
                itemCount = int.Parse(item.text);
                item.text = (itemCount + 1).ToString();

                pickupSound.Play();
                rend.enabled = false;
                col.enabled = false;
                Destroy(gameObject,pickupSound.clip.length);

            }
            else if(this.CompareTag("Food")){
                Instantiate(effect, transform.position, Quaternion.identity);
                item = (GameObject.FindGameObjectWithTag("FoodCount").GetComponent<TMPro.TextMeshProUGUI>());
                
                itemCount = int.Parse(item.text);
                item.text = (itemCount + 1).ToString();

                pickupSound.Play();
                rend.enabled = false;
                col.enabled = false;

                Destroy(gameObject,pickupSound.clip.length);

            }
            else if(this.CompareTag("Sword")){
                Instantiate(effect, transform.position, Quaternion.identity);
                item = (GameObject.FindGameObjectWithTag("SwordCount").GetComponent<TMPro.TextMeshProUGUI>());
                
                itemCount = int.Parse(item.text);
                item.text = (itemCount + 1).ToString();

                pickupSound.Play();
                rend.enabled = false;
                col.enabled = false;
                
                Destroy(gameObject,pickupSound.clip.length);

            }


        }
        
    }
}
