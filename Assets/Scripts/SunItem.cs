using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SunItem : MonoBehaviour {

    private Image img;
    private Button btn;

    private Transform player;
    public GameObject explosionEffect;
    private AudioSource useSound; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        useSound = GetComponent<AudioSource>();
        img = GetComponent<Image>();
        btn = GetComponent<Button>();
    }

    public void Use() {
        Instantiate(explosionEffect, player.transform.position, Quaternion.identity);
        useSound.Play();
        img.enabled = false;
        btn.enabled = false;

        Destroy(gameObject,useSound.clip.length);
    }

}
