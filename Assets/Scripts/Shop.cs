using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    bool isClosed = true;
    public GameObject shopBag;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("wtf");
        if (other.CompareTag("Player")) {
            if (isClosed == true)
            {
                shopBag.SetActive(true);
                isClosed = false;
            }
            else {
                shopBag.SetActive(false);
                isClosed = true;
            }   
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isClosed = true;
            shopBag.SetActive(false);
        }
        
    }
}
