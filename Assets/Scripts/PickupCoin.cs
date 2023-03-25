using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private Renderer rend;
    private CircleCollider2D col;

    private TMPro.TextMeshProUGUI coinCounter;
    private AudioSource pickupSound; 
    private int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        col = GetComponent<CircleCollider2D>();
        coinCounter = (GameObject.FindGameObjectWithTag("CoinCount").GetComponent<TMPro.TextMeshProUGUI>());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            coinCount = int.Parse(coinCounter.text);
            coinCounter.text = (coinCount + 1).ToString();
            pickupSound.Play();
            rend.enabled = false;
            col.enabled = false;

            Destroy(gameObject,GetComponent<AudioSource>().clip.length);
        }
    }
}
