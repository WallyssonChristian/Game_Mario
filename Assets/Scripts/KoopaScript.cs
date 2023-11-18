using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaScript : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer render;

    public int direction = -1;
    public float velocity = 2f;

    public bool isAlive = true;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
		if (isAlive) {
            rb.velocity = new Vector2(velocity * direction, rb.velocity.y);
        }

        animator.SetFloat("velocity", GetAbsRunVelocity());
	}

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Platform") && isAlive) {
            rb.velocity = new Vector2(0, rb.velocity.y);
            direction = -direction;
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1,
                                                    this.transform.localScale.y,
                                                    this.transform.localScale.z);

        }
    }

    public float GetAbsRunVelocity() {
        return Mathf.Abs(rb.velocity.x);
    }
}
