using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour {

    public Transform target;

    private Animator animator;
    public CharacterController character;

    bool tookDamage = false;
    bool dead = false;
    bool attack = false;
    bool grounded = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        

        float move = Input.GetAxis("Horizontal");

        if(move > 0)
        {
            transform.localScale = new Vector3(.5f, .5f, .5f);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-.5f, .5f, .5f);
        }
        animator.SetFloat("speed", Mathf.Abs(character.velocity.x));
        grounded = character.isGrounded;
        animator.SetBool("isJumping", !grounded);

        if (Input.GetKeyDown(KeyCode.LeftAlt) && !dead)
        {
            attack = true;
            animator.SetBool("attack", true);
            animator.SetFloat("speed", 0);

        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            attack = false;
            animator.SetBool("attack", false);
        }

         if (!grounded && Input.GetButtonDown("Jump") && !dead)
        {
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            tookDamage = true;
            animator.SetBool("tookDamage", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            tookDamage = false;
            animator.SetBool("tookDamage", false);
        }
        //dead animation for testing//
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!dead)
            {
                animator.SetBool("dead", true);
                animator.SetFloat("speed", 0);
                dead = true;
            }
            else
            { 
                animator.SetBool("dead", false);
                animator.SetFloat("speed", 0);
                dead = false;
            }
        }
    }

    void LateUpdate()
    {
        transform.localPosition = new Vector3(target.localPosition.x, transform.localPosition.y, target.localPosition.z);
    }
}
