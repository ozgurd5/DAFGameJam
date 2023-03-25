using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPickup : MonoBehaviour {
    private TMPro.TextMeshProUGUI item;
    private int itemCount;
    public GameObject effect;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {

            if(this.CompareTag("Health")){
                Instantiate(effect, transform.position, Quaternion.identity);
                item = (GameObject.FindGameObjectWithTag("HealthCount").GetComponent<TMPro.TextMeshProUGUI>());
                
                itemCount = int.Parse(item.text);
                item.text = (itemCount + 1).ToString();
                Destroy(gameObject);
            }
            else if(this.CompareTag("Food")){
                Instantiate(effect, transform.position, Quaternion.identity);
                item = (GameObject.FindGameObjectWithTag("FoodCount").GetComponent<TMPro.TextMeshProUGUI>());
                
                itemCount = int.Parse(item.text);
                item.text = (itemCount + 1).ToString();

                Destroy(gameObject);
            }
            else if(this.CompareTag("Sword")){
                Instantiate(effect, transform.position, Quaternion.identity);
                item = (GameObject.FindGameObjectWithTag("SwordCount").GetComponent<TMPro.TextMeshProUGUI>());
                
                itemCount = int.Parse(item.text);
                item.text = (itemCount + 1).ToString();

                Destroy(gameObject);
            }


        }
        
    }
}
