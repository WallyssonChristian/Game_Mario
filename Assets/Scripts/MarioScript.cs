using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour {

    GameBehaviour game;

    MarioColliderHelper bottonHelper;
    MarioColliderHelper rightHelper;
    MarioColliderHelper leftHelper;

    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sRender;

    public bool isDead = false;
    public bool isJumping = false;
    public float speed = 5f;

    public float jumpForce = 500f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sRender = GetComponent<SpriteRenderer>();

        game = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();

        bottonHelper = GetComponentsInChildren<MarioColliderHelper>()[0];
        rightHelper = GetComponentsInChildren<MarioColliderHelper>()[1];
        leftHelper = GetComponentsInChildren<MarioColliderHelper>()[2];
    }

	void FixedUpdate () {
        if (game.isGameRunning == false) {
            ani.SetFloat("velocity", 0);
            return;
        }


        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.D) && rightHelper.isCollinding == false)
        {
            dir.x = 1;
        } else if (Input.GetKey(KeyCode.A) && leftHelper.isCollinding == false)
        {
            dir.x = -1;
        }

        if (Input.GetKey(KeyCode.W) && isJumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce));
        }

        isJumping = !bottonHelper.isCollinding;

        Vector2 vel = rb.velocity;  // vetor 2 recebe velocidade do RigidBody (mario)
                                    //vel.y = dir.y * 30;
        vel.x = dir.x * speed;  // eixo X do vetor velocidade recebe a direção que
                                // o mario esta indo ( +1 ou -1 ) e multiplica pela velocidade de movimento
        rb.velocity = vel;  // a velocidade do rigidbody do mario é alterada para a
                            // velocidade do vetor2, assim ela é multiplicada pelo speed

        ani.SetFloat("velocity", GetAbsRunVelocity());
        ani.SetBool("jump", IsJumping());

        if (rb.velocity.x > 0)
        {
            sRender.flipX = true;
        } else if (rb.velocity.x < 0)
        {
            sRender.flipX = false;
        }

        if (Input.GetKey(KeyCode.H))
        {
            ani.SetBool("dead", true);
        }
	}

    public float GetAbsRunVelocity()
    {
        return Mathf.Abs(rb.velocity.x);
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    public bool IsDead()
    {
        return isDead;
    }

}
