using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    SpriteRenderer rendererSprite;
    AudioSource plin;
    bool readyToRemove = false;

    private void Start() {
        plin = GetComponent<AudioSource>();
        rendererSprite = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (readyToRemove == true && plin.isPlaying == false) {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D coll) {

        
        if (coll.CompareTag("Mario") == true && readyToRemove == false) {
            plin.Play();
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddCoin();
            readyToRemove = true;
            rendererSprite.enabled = false;
        } 
    }

    
}
