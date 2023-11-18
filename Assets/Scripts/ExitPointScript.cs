using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPointScript : MonoBehaviour {

    public string NextLevel = null;

    public float loadDelay = 3f;
    private float counter = 0f;
    bool loadNextLevel = false;


	void Update () {
		if (loadNextLevel) {
            counter += Time.deltaTime;
            if (counter >= loadDelay) {
                loadNextLevel = false;
                SceneManager.LoadScene(NextLevel);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Mario")) {
            GameBehaviour game = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();
            if (game.isGameRunning) {
                game.isGameRunning = false;
                if (string.IsNullOrEmpty (NextLevel) == false) {
                    loadNextLevel = true;
                }
            }
        }
    }
}
