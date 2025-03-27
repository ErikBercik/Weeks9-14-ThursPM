using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    SpriteRenderer sr;
    Animator animator;
    public float speed = 3;
    public bool canRun = true;

    public AudioSource footsteps;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        //This gives us a number between -1 and 1 to know direction

        sr.flipX = (direction < 0);
        animator.SetFloat("movement", Mathf.Abs(direction));  //we want to use absolute because movement needs to stay above 1 for sprite animation to work

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        if (canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }

    }

    public void FootstepMaker()
    {
        Debug.Log("Whack!");
        footsteps.Play();
    }

    public void AttackHasFinished()
    {
        Debug.Log("Attack is over dawg");
        canRun = true;
    }
}
