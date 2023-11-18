using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour {

    public int coins = 0;
    public bool isGameRunning;

    private void Start() {
        GameObject startPoint = GameObject.Find("startPoint");
        if (startPoint == null) {
            throw new UnityException("Start point does not exists!");
        }

        GameObject mario = GameObject.Find("Mario");
        if (mario == null) {
            throw new UnityException("Mario does not exists!");
        }

        mario.transform.position = startPoint.transform.position;
        isGameRunning = true;
    }


    public void AddCoin() {
        coins += 1;
    }
}
