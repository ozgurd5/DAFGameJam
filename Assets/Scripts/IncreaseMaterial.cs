using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaterial : MonoBehaviour
{
    public TMPro.TextMeshProUGUI materialCounter;
    public TMPro.TextMeshProUGUI coinCounter;


    private int materialCount;
    private int coinCount;

    public int cost = 1;

    // Update is called once per frame
    public void increaseMaterial()
    {
        materialCount = int.Parse(materialCounter.text);
        coinCount = int.Parse(coinCounter.text);

        Debug.Log(materialCount);

        if(coinCount >= cost){
            coinCount -= cost;
            coinCounter.text = (coinCount).ToString();

            materialCounter.text = (materialCount + 1).ToString();
        }
    }
}
