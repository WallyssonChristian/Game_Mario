using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBoxScript : MonoBehaviour {

    Animator animator;
    AudioSource plin;

    public bool isActive = false;


    void Start () {
        animator = GetComponent<Animator>();
        plin = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Mario") && !isActive) {
            isActive = true;
            animator.SetBool("Active", isActive);
            plin.PlayDelayed (0.15f);
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddCoin();
        }
    }
}
