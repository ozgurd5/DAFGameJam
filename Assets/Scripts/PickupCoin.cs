using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private TMPro.TextMeshProUGUI coinCounter;
    private int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ashfgcjs");
        coinCounter = (GameObject.FindGameObjectWithTag("CoinCount").GetComponent<TMPro.TextMeshProUGUI>());
        Debug.Log("ashfgcjsasxas");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            coinCount = int.Parse(coinCounter.text);
            coinCounter.text = (coinCount + 1).ToString();
            Destroy(gameObject);
        }
    }
}
