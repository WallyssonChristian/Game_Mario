using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioColliderHelper : MonoBehaviour {

    public bool isCollinding = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Platform") == true) {
            isCollinding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Platform") == true) {
            isCollinding = false;
        }
    }
}
